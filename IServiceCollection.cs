using System;

namespace FlightsProject
{
    public interface IServiceCollection
    {
        void AddControllers();
        object AddAuthentication(object authenticationScheme);
        object AddAuthentication(Action<object> p);
        void AddScoped<T1, T2>();
    }
}