using System;

namespace FlightsProject
{
    public interface IApplicationBuilder
    {
        void UseDeveloperExceptionPage();
        void UseHttpsRedirection();
        void UseRouting();
        void UseAuthentication();
        void UseAuthorization();
        void UseEndpoints(Action<object> p);
    }
}