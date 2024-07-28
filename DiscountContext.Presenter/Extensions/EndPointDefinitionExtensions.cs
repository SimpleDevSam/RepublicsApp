using DiscountContext.Presenter.Abstractions;

namespace DiscountContext.Presenter.Extensions
{
    public static class EndpointDefinitionExtensions
    {
        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            IEnumerable<IEndPointDefinition> endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndPointDefinition)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndPointDefinition>();

            foreach (var endpointDef in endpointDefinitions)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
    }
}