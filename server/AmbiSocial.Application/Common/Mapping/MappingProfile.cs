namespace AmbiSocial.Application.Common.Mapping;

using System.Reflection;

using AutoMapper;

public class MappingProfile : Profile
{
    private const string MemberMappingMethodName = "Mapping";

    public MappingProfile(Assembly assembly)
        => this.ApplyMappingsFromAssembly(assembly);

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t
                .GetInterfaces()
                .Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod(MemberMappingMethodName)
                             ?? type.GetInterface("IMapFrom`1")?.GetMethod(MemberMappingMethodName);

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}