﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using JetBrains.Annotations;

using Mono.Cecil;

namespace AutoProperties.Fody
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    internal class SystemReferences
    {
        public SystemReferences([NotNull] ModuleDefinition moduleDefinition, [NotNull] IAssemblyResolver assemblyResolver)
        {
            var assemblies = new[] { "mscorlib", "System.Reflection", "System.Runtime" };
            var coreTypes = assemblies.SelectMany(assembly => GetTypes(assemblyResolver, assembly)).ToArray();

            var fieldInfoType = coreTypes.First(x => x.Name == "FieldInfo");
            GetFieldFromHandle = moduleDefinition.ImportReference(fieldInfoType.Methods
                .First(x => (x.Name == "GetFieldFromHandle") &&
                            (x.Parameters.Count == 1) &&
                            (x.Parameters[0].ParameterType.Name == "RuntimeFieldHandle")));

            PropertyInfoType = moduleDefinition.ImportReference(coreTypes.First(x => x.Name == "PropertyInfo"));

            var typeType = coreTypes.First(x => x.Name == "Type");
            GetTypeFromHandle = moduleDefinition.ImportReference(typeType.Methods
                .First(x => (x.Name == "GetTypeFromHandle") &&
                            (x.Parameters.Count == 1) &&
                            (x.Parameters[0].ParameterType.Name == "RuntimeTypeHandle")));

            GetPropertyInfo = moduleDefinition.ImportReference(typeType.Methods
                .First(x => (x.Name == "GetProperty") &&
                            (x.Parameters.Count == 1) &&
                            (x.Parameters[0].ParameterType.Name == "String")));
        }

        [NotNull]
        public MethodReference GetTypeFromHandle { get; }
        [NotNull]
        public TypeReference PropertyInfoType { get; }
        [NotNull]
        public MethodReference GetFieldFromHandle { get; }
        [NotNull]
        public MethodReference GetPropertyInfo { get; }

        [NotNull, ItemNotNull]
        private static IEnumerable<TypeDefinition> GetTypes([NotNull] IAssemblyResolver assemblyResolver, [NotNull] string name)
        {
            return assemblyResolver.Resolve(new AssemblyNameReference(name, null))?.MainModule.Types ?? Enumerable.Empty<TypeDefinition>();
        }
    }
}