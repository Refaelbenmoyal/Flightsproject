(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports) :
        typeof define === 'function' && define.amd ? define(['exports'], factory) :
            (global = global || self, factory(global.Redux = {}));
}(this, function (exports) {
    'use strict';

    function symbolObservablePonyfill(root) {
        var result;
        var Symbol = root.Symbol;

        if (typeof Symbol === 'function') {
            if (Symbol.observable) {
                result = Symbol.observable;
            } else {
                result = Symbol('observable');
                Symbol.observable = result;
            }
        } else {
            result = '@@observable';
        }

        return result;
    }

 

    var root;

    if (typeof self !== 'undefined') {
        root = self;
    } else if (typeof window !== 'undefined') {
        root = window;
    } else if (typeof global !== 'undefined') {
        root = global;
    } else if (typeof module !== 'undefined') {
        root = module;
    } else {
        root = Function('return this')();
    }

    var result = symbolObservablePonyfill(root);

  
    var randomString = function randomString() {
        return Math.random().toString(36).substring(7).split('').join('.');
    };

    var ActionTypes = {
        INIT: "@@redux/INIT" + randomString(),
        REPLACE: "@@redux/REPLACE" + randomString(),
        PROBE_UNKNOWN_ACTION: function PROBE_UNKNOWN_ACTION() {
            return "@@redux/PROBE_UNKNOWN_ACTION" + randomString();
        }
    };

  
    function isPlainObject(obj) {
        if (typeof obj !== 'object' || obj === null) return false;
        var proto = obj;

        while (Object.getPrototypeOf(proto) !== null) {
            proto = Object.getPrototypeOf(proto);
        }

        return Object.getPrototypeOf(obj) === proto;
    }

   

    function createStore(reducer, preloadedState, enhancer) {
        var _ref2;

        if (typeof preloadedState === 'function' && typeof enhancer === 'function' || typeof enhancer === 'function' && typeof arguments[3] === 'function') {
            throw new Error('It looks like you are passing several store enhancers to ' + 'createStore(). This is not supported. Instead, compose them ' + 'together to a single function.');
        }

        if (typeof preloadedState === 'function' && typeof enhancer === 'undefined') {
            enhancer = preloadedState;
            preloadedState = undefined;
        }

        if (typeof enhancer !== 'undefined') {
            if (typeof enhancer !== 'function') {
                throw new Error('Expected the enhancer to be a function.');
            }

            return enhancer(createStore)(reducer, preloadedState);
        }

        if (typeof reducer !== 'function') {
            throw new Error('Expected the reducer to be a function.');
        }

        var currentReducer = reducer;
        var currentState = preloadedState;
        var currentListeners = [];
        var nextListeners = currentListeners;
        var isDispatching = false;
       

        function ensureCanMutateNextListeners() {
            if (nextListeners === currentListeners) {
                nextListeners = currentListeners.slice();
            }
        }
       


        function getState() {
            if (isDispatching) {
                throw new Error('You may not call store.getState() while the reducer is executing. ' + 'The reducer has already received the state as an argument. ' + 'Pass it down from the top reducer instead of reading it from the store.');
            }

            return currentState;
        }
       


        function subscribe(listener) {
            if (typeof listener !== 'function') {
                throw new Error('Expected the listener to be a function.');
            }

            if (isDispatching) {
                throw new Error('You may not call store.subscribe() while the reducer is executing. ' + 'If you would like to be notified after the store has been updated, subscribe from a ' + 'component and invoke store.getState() in the callback to access the latest state. ' + 'See https://redux.js.org/api-reference/store#subscribelistener for more details.');
            }

            var isSubscribed = true;
            ensureCanMutateNextListeners();
            nextListeners.push(listener);
            return function unsubscribe() {
                if (!isSubscribed) {
                    return;
                }

                if (isDispatching) {
                    throw new Error('You may not unsubscribe from a store listener while the reducer is executing. ' + 'See https://redux.js.org/api-reference/store#subscribelistener for more details.');
                }

                isSubscribed = false;
                ensureCanMutateNextListeners();
                var index = nextListeners.indexOf(listener);
                nextListeners.splice(index, 1);
                currentListeners = null;
            };
        }
      


        function dispatch(action) {
            if (!isPlainObject(action)) {
                throw new Error('Actions must be plain objects. ' + 'Use custom middleware for async actions.');
            }

            if (typeof action.type === 'undefined') {
                throw new Error('Actions may not have an undefined "type" property. ' + 'Have you misspelled a constant?');
            }

            if (isDispatching) {
                throw new Error('Reducers may not dispatch actions.');
            }

            try {
                isDispatching = true;
                currentState = currentReducer(currentState, action);
            } finally {
                isDispatching = false;
            }

            var listeners = currentListeners = nextListeners;

            for (var i = 0; i < listeners.length; i++) {
                var listener = listeners[i];
                listener();
            }

            return action;
        }
       


        function replaceReducer(nextReducer) {
            if (typeof nextReducer !== 'function') {
                throw new Error('Expected the nextReducer to be a function.');
            }

            currentReducer = nextReducer; 

            dispatch({
                type: ActionTypes.REPLACE
            });
        }
       


        function observable() {
            var _ref;

            var outerSubscribe = subscribe;
            return _ref = {
                
                subscribe: function subscribe(observer) {
                    if (typeof observer !== 'object' || observer === null) {
                        throw new TypeError('Expected the observer to be an object.');
                    }

                    function observeState() {
                        if (observer.next) {
                            observer.next(getState());
                        }
                    }

                    observeState();
                    var unsubscribe = outerSubscribe(observeState);
                    return {
                        unsubscribe: unsubscribe
                    };
                }
            }, _ref[result] = function () {
                return this;
            }, _ref;
        } 


        dispatch({
            type: ActionTypes.INIT
        });
        return _ref2 = {
            dispatch: dispatch,
            subscribe: subscribe,
            getState: getState,
            replaceReducer: replaceReducer
        }, _ref2[result] = observable, _ref2;
    }

    
    function warning(message) {
       
        if (typeof console !== 'undefined' && typeof console.error === 'function') {
            console.error(message);
        }
       
        try {
           
            throw new Error(message);
        } catch (e) { }

    }

    function getUndefinedStateErrorMessage(key, action) {
        var actionType = action && action.type;
        var actionDescription = actionType && "action \"" + String(actionType) + "\"" || 'an action';
        return "Given " + actionDescription + ", reducer \"" + key + "\" returned undefined. " + "To ignore an action, you must explicitly return the previous state. " + "If you want this reducer to hold no value, you can return null instead of undefined.";
    }

    function getUnexpectedStateShapeWarningMessage(inputState, reducers, action, unexpectedKeyCache) {
        var reducerKeys = Object.keys(reducers);
        var argumentName = action && action.type === ActionTypes.INIT ? 'preloadedState argument passed to createStore' : 'previous state received by the reducer';

        if (reducerKeys.length === 0) {
            return 'Store does not have a valid reducer. Make sure the argument passed ' + 'to combineReducers is an object whose values are reducers.';
        }

        if (!isPlainObject(inputState)) {
            return "The " + argumentName + " has unexpected type of \"" + {}.toString.call(inputState).match(/\s([a-z|A-Z]+)/)[1] + "\". Expected argument to be an object with the following " + ("keys: \"" + reducerKeys.join('", "') + "\"");
        }

        var unexpectedKeys = Object.keys(inputState).filter(function (key) {
            return !reducers.hasOwnProperty(key) && !unexpectedKeyCache[key];
        });
        unexpectedKeys.forEach(function (key) {
            unexpectedKeyCache[key] = true;
        });
        if (action && action.type === ActionTypes.REPLACE) return;

        if (unexpectedKeys.length > 0) {
            return "Unexpected " + (unexpectedKeys.length > 1 ? 'keys' : 'key') + " " + ("\"" + unexpectedKeys.join('", "') + "\" found in " + argumentName + ". ") + "Expected to find one of the known reducer keys instead: " + ("\"" + reducerKeys.join('", "') + "\". Unexpected keys will be ignored.");
        }
    }

    function assertReducerShape(reducers) {
        Object.keys(reducers).forEach(function (key) {
            var reducer = reducers[key];
            var initialState = reducer(undefined, {
                type: ActionTypes.INIT
            });

            if (typeof initialState === 'undefined') {
                throw new Error("Reducer \"" + key + "\" returned undefined during initialization. " + "If the state passed to the reducer is undefined, you must " + "explicitly return the initial state. The initial state may " + "not be undefined. If you don't want to set a value for this reducer, " + "you can use null instead of undefined.");
            }

            if (typeof reducer(undefined, {
                type: ActionTypes.PROBE_UNKNOWN_ACTION()
            }) === 'undefined') {
                throw new Error("Reducer \"" + key + "\" returned undefined when probed with a random type. " + ("Don't try to handle " + ActionTypes.INIT + " or other actions in \"redux/*\" ") + "namespace. They are considered private. Instead, you must return the " + "current state for any unknown actions, unless it is undefined, " + "in which case you must return the initial state, regardless of the " + "action type. The initial state may not be undefined, but can be null.");
            }
        });
    }
   


    function combineReducers(reducers) {
        var reducerKeys = Object.keys(reducers);
        var finalReducers = {};

        for (var i = 0; i < reducerKeys.length; i++) {
            var key = reducerKeys[i];

            {
                if (typeof reducers[key] === 'undefined') {
                    warning("No reducer provided for key \"" + key + "\"");
                }
            }

            if (typeof reducers[key] === 'function') {
                finalReducers[key] = reducers[key];
            }
        }

        var finalReducerKeys = Object.keys(finalReducers); // This is used to make sure we don't warn about the same
       
        var unexpectedKeyCache;

        {
            unexpectedKeyCache = {};
        }

        var shapeAssertionError;

        try {
            assertReducerShape(finalReducers);
        } catch (e) {
            shapeAssertionError = e;
        }

        return function combination(state, action) {
            if (state === void 0) {
                state = {};
            }

            if (shapeAssertionError) {
                throw shapeAssertionError;
            }

            {
                var warningMessage = getUnexpectedStateShapeWarningMessage(state, finalReducers, action, unexpectedKeyCache);

                if (warningMessage) {
                    warning(warningMessage);
                }
            }

            var hasChanged = false;
            var nextState = {};

            for (var _i = 0; _i < finalReducerKeys.length; _i++) {
                var _key = finalReducerKeys[_i];
                var reducer = finalReducers[_key];
                var previousStateForKey = state[_key];
                var nextStateForKey = reducer(previousStateForKey, action);

                if (typeof nextStateForKey === 'undefined') {
                    var errorMessage = getUndefinedStateErrorMessage(_key, action);
                    throw new Error(errorMessage);
                }

                nextState[_key] = nextStateForKey;
                hasChanged = hasChanged || nextStateForKey !== previousStateForKey;
            }

            hasChanged = hasChanged || finalReducerKeys.length !== Object.keys(state).length;
            return hasChanged ? nextState : state;
        };
    }

    function bindActionCreator(actionCreator, dispatch) {
        return function () {
            return dispatch(actionCreator.apply(this, arguments));
        };
    }
    
    function bindActionCreators(actionCreators, dispatch) {
        if (typeof actionCreators === 'function') {
            return bindActionCreator(actionCreators, dispatch);
        }

        if (typeof actionCreators !== 'object' || actionCreators === null) {
            throw new Error("bindActionCreators expected an object or a function, instead received " + (actionCreators === null ? 'null' : typeof actionCreators) + ". " + "Did you write \"import ActionCreators from\" instead of \"import * as ActionCreators from\"?");
        }

        var boundActionCreators = {};

        for (var key in actionCreators) {
            var actionCreator = actionCreators[key];

            if (typeof actionCreator === 'function') {
                boundActionCreators[key] = bindActionCreator(actionCreator, dispatch);
            }
        }

        return boundActionCreators;
    }

    function _defineProperty(obj, key, value) {
        if (key in obj) {
            Object.defineProperty(obj, key, {
                value: value,
                enumerable: true,
                configurable: true,
                writable: true
            });
        } else {
            obj[key] = value;
        }

        return obj;
    }

    function ownKeys(object, enumerableOnly) {
        var keys = Object.keys(object);

        if (Object.getOwnPropertySymbols) {
            keys.push.apply(keys, Object.getOwnPropertySymbols(object));
        }

        if (enumerableOnly) keys = keys.filter(function (sym) {
            return Object.getOwnPropertyDescriptor(object, sym).enumerable;
        });
        return keys;
    }

    function _objectSpread2(target) {
        for (var i = 1; i < arguments.length; i++) {
            var source = arguments[i] != null ? arguments[i] : {};

            if (i % 2) {
                ownKeys(source, true).forEach(function (key) {
                    _defineProperty(target, key, source[key]);
                });
            } else if (Object.getOwnPropertyDescriptors) {
                Object.defineProperties(target, Object.getOwnPropertyDescriptors(source));
            } else {
                ownKeys(source).forEach(function (key) {
                    Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key));
                });
            }
        }

        return target;
    }

  
    function compose() {
        for (var _len = arguments.length, funcs = new Array(_len), _key = 0; _key < _len; _key++) {
            funcs[_key] = arguments[_key];
        }

        if (funcs.length === 0) {
            return function (arg) {
                return arg;
            };
        }

        if (funcs.length === 1) {
            return funcs[0];
        }

        return funcs.reduce(function (a, b) {
            return function () {
                return a(b.apply(void 0, arguments));
            };
        });
    }

    function applyMiddleware() {
        for (var _len = arguments.length, middlewares = new Array(_len), _key = 0; _key < _len; _key++) {
            middlewares[_key] = arguments[_key];
        }

        return function (createStore) {
            return function () {
                var store = createStore.apply(void 0, arguments);

                var _dispatch = function dispatch() {
                    throw new Error('Dispatching while constructing your middleware is not allowed. ' + 'Other middleware would not be applied to this dispatch.');
                };

                var middlewareAPI = {
                    getState: store.getState,
                    dispatch: function dispatch() {
                        return _dispatch.apply(void 0, arguments);
                    }
                };
                var chain = middlewares.map(function (middleware) {
                    return middleware(middlewareAPI);
                });
                _dispatch = compose.apply(void 0, chain)(store.dispatch);
                return _objectSpread2({}, store, {
                    dispatch: _dispatch
                });
            };
        };
    }

    function isCrushed() { }

    if (typeof isCrushed.name === 'string' && isCrushed.name !== 'isCrushed') {
        warning('You are currently using minified code outside of NODE_ENV === "production". ' + 'This means that you are running a slower development build of Redux. ' + 'You can use loose-envify (https://github.com/zertosh/loose-envify) for browserify ' + 'or setting mode to production in webpack (https://webpack.js.org/concepts/mode/) ' + 'to ensure you have the correct code for your production build.');
    }

    exports.__DO_NOT_USE__ActionTypes = ActionTypes;
    exports.applyMiddleware = applyMiddleware;
    exports.bindActionCreators = bindActionCreators;
    exports.combineReducers = combineReducers;
    exports.compose = compose;
    exports.createStore = createStore;

    Object.defineProperty(exports, '__esModule', { value: true });

}));
