using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eventarin.Core
{
	/// <summary>
	/// Простая реализация инверсии управления (Inversion of Control)
	/// </summary>
	public class SimpleIoC
	{
		#region public methods
		/// <summary>
		/// 
		/// </summary>
		public SimpleIoC()
		{
			RegisterInstance(this);
		}

		/// <summary>
		/// Register type
		/// </summary>
		/// <typeparam name="TType">registered class</typeparam>
		public void Register<TType>() where TType : class
		{
			Register<TType, TType>(false, null);
		}

		/// <summary>
		/// Register an instance of type
		/// </summary>
		/// <typeparam name="TType">registered type</typeparam>
		/// <typeparam name="TLive">instance of the class</typeparam>
		public void Register<TType, TLive>() where TLive : class, TType
		{
			Register<TType, TLive>(false, null);
		}

		/// <summary>
		/// Register type (Singleton)
		/// </summary>
		/// <typeparam name="TType">registered type</typeparam>
		public void RegisterSingleton<TType>() where TType : class
		{
			RegisterSingleton<TType, TType>();
		}

		/// <summary>
		/// Registers type (Singleton)
		/// </summary>
		/// <param name="type">The type to register</param>
		public void RegisterSingleton(Type type)
		{
			Register(type, true, null);
		}

		/// <summary>
		/// Register an instance of type (Singleton)
		/// </summary>
		/// <typeparam name="TType">registered type</typeparam>
		/// <typeparam name="TLive">instance of the class</typeparam>
		public void RegisterSingleton<TType, TLive>() where TLive : class, TType
		{
			Register<TType, TLive>(true, null);
		}

		/// <summary>
		/// Register type to instance
		/// </summary>
		/// <typeparam name="TType">registered type</typeparam>
		/// <typeparam name="TLive">instance of the class</typeparam>
		public void RegisterInstance<TType>(TType instance) where TType : class
		{
			RegisterInstance<TType, TType>(instance);
		}

		/// <summary>
		/// Register the instance and type
		/// </summary>
		/// <typeparam name="TType">registered type</typeparam>
		/// <typeparam name="TLive">instance of the class</typeparam>
		/// <param name="instance"></param>
		public void RegisterInstance<TType, TLive>(TLive instance) where TLive : class, TType
		{
			Register<TType, TLive>(true, instance);
		}

		/// <summary>
		/// Resolve type
		/// </summary>
		/// <typeparam name="TResolve">resolvable type</typeparam>
		/// <returns>to</returns>
		public TResolve Resolve<TResolve>()
		{
			return (TResolve)ResolveObject(typeof(TResolve));
		}

		/// <summary>
		/// Resolve type
		/// </summary>
		/// <param name="type">resolvable type</param>
		/// <returns>to</returns>
		public object Resolve(Type type)
		{
			return ResolveObject(type);
		}
		#endregion public methods

		#region private methods
		private void Register<TType, TLive>(bool isSingleton, TLive instance)
		{
			Type type = typeof(TType); 
			if (_registeredObjects.ContainsKey(type))
			{
				_registeredObjects.Remove(type); 
			}
			_registeredObjects.Add(type, new EnteredObject(typeof(TLive), isSingleton, instance));
		}

		private void Register(Type type, bool isSingleton, object instance)
		{
			if (_registeredObjects.ContainsKey(type))
			{
				_registeredObjects.Remove(type); 
			}
			_registeredObjects.Add(type, new EnteredObject(type, isSingleton, instance));
		}

		private object ResolveObject(Type type)
		{
			var registeredObject = _registeredObjects[type]; 
			if (registeredObject == null) 
			{ 
				throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name)); 
			} 
			return GetInstance(registeredObject);
		}

		private object GetInstance(EnteredObject registeredObject)
		{
			object instance = registeredObject.SingletonInstance;
			if (instance == null)
			{
				var parameters = ResolveConstructorParameters(registeredObject);
				instance = registeredObject.CreateInstance(parameters.ToArray());
			}
			return instance;
		}

		private IEnumerable<object> ResolveConstructorParameters(EnteredObject registeredObject)
		{
			var constructorInfo = registeredObject.LiveType.GetTypeInfo().DeclaredConstructors.First();
			return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
		}

		/// <summary>
		/// the object being registered
		/// </summary>
		private class EnteredObject
		{
			private readonly bool _isSinglton;
			public EnteredObject(Type liveType, bool isSingleton, object instance)
			{
				_isSinglton = isSingleton;
				LiveType = liveType;
				SingletonInstance = instance;
			}
			public Type LiveType
			{
				get;
				private set;
			}
			public object SingletonInstance
			{
				get;
				private set;
			}

			public object CreateInstance(params object[] args)
			{
				object instance = Activator.CreateInstance(LiveType, args);
				if (_isSinglton)
					SingletonInstance = instance;
				return instance;
			}
		}
		#endregion private methods

		#region MyRegion
		private readonly IDictionary<Type, EnteredObject> _registeredObjects = new Dictionary<Type, EnteredObject>();
		#endregion
	}
}