namespace Koi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Koi.Tests.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The koi unit test.
    /// </summary>
    [TestClass]
    public class KoiUnitTest
    {
        /// <summary>
        /// The container.
        /// </summary>
        private KoiContainer container;

        /// <summary>
        /// The initialise.
        /// </summary>
        [TestInitialize]
        public void Initialise()
        {
            this.container = new KoiContainer();
        }

        /// <summary>
        /// The should be able to get instance.
        /// </summary>
        [TestMethod]
        public void ShouldBeAbleToGetInstance()
        {
            // arrange
            this.container.RegisterType<IEmailService, EmailService>(Lifetime.PerResolve);
            this.container.RegisterType<IRepo, Repo>(Lifetime.PerResolve);
            this.container.RegisterType<IQuery, Query>(Lifetime.PerResolve);

            // act
            var instance = this.container.Resolve(typeof(IQuery)) as Query;

            // assert
            Assert.IsInstanceOfType(instance, typeof(Query));
        }

        [TestMethod]
        public void PerResolveStratsShouldntActAsSingleton()
        {
            // arrange
            this.container.RegisterType<IContext, Context>(Lifetime.PerResolve);

            // act
            var instance1 = this.container.Resolve(typeof(IContext)) as Context;

            instance1.Increment(10);

            var instance2 = this.container.Resolve(typeof(IContext)) as Context;

            instance2.Increment(5);

            // assert
            Assert.AreNotEqual(15, instance2.Increments);

            Assert.AreEqual(10, instance1.Increments);
            Assert.AreEqual(5, instance2.Increments);
        }

        [TestMethod]
        public void SingletonInstancesShouldReturnSameValue()
        {
            // arrange
            this.container.RegisterType<IContext, Context>(Lifetime.Singleton);

            // act
            var instance1 = this.container.Resolve(typeof(IContext)) as Context;

            instance1.Increment(10);

            var instance2 = this.container.Resolve(typeof(IContext)) as Context;

            instance2.Increment(5);

            // assert
            Assert.AreEqual(15, instance2.Increments);
        }

        [TestMethod]
        public void RegisterInstanceWithFactoryShouldReturnCorrectInstance()
        {
            // arrange
            var store = new Store();
            store.SetId(30);

            this.container.RegisterInstance<Store>(() => store, Lifetime.PerResolve);

            // act
            var resolveStore = this.container.Resolve(typeof(Store));

            // assert
            Assert.AreEqual(30, ((Store)resolveStore).Id);
        }

        [TestMethod]
        public void CanRegisterMultipleTypes()
        {
            // arrage
            this.container.RegisterType<IEmailService, EmailService>(Lifetime.PerResolve);
            this.container.RegisterType<IEmailService, BetterEmailService>(Lifetime.PerResolve);

            // act
            var instance = this.container.ResolveAll(typeof(IEmailService));

            // Assert
            Assert.IsInstanceOfType(instance, typeof(IEnumerable<object>));
        }

        [TestMethod]
        public void ResolveOpenToClosedGenericTypes()
        {
            // arrange
            this.container.RegisterTypesFromAssembly(typeof(TestQueryHandler).Assembly);

            var type = typeof(IQueryHandler<,>);

            // act
            var types = this.container.ResolveAll(type);

            // assert
            types.ToList().ForEach(
                x =>
                    {
                        var closedGenericInterface = x.GetType().GetInterfaces().FirstOrDefault();
                        var genericTypeDefinition = closedGenericInterface.GetGenericTypeDefinition();

                        Assert.AreEqual(genericTypeDefinition, type);
                    });
        }

        [TestMethod]
        public void RegisterAllInAssembly()
        {
            // arrange
            this.container.RegisterTypesFromAssembly(typeof(TestQueryHandler).Assembly);

            // act
            var ctx = this.container.Resolve(typeof(IContext)) as Context;
            var em = this.container.Resolve(typeof(IEmailService)) as EmailService;
            var query = this.container.ResolveAll(typeof(IQuery<>)).ToArray();



            // Assert
            Assert.IsInstanceOfType(ctx, typeof(Context));
            Assert.IsInstanceOfType(em, typeof(EmailService));

            var implementedClosedGenericQueries = new List<Type> { typeof(MadQuery), typeof(TestQuery) };

            AssertExtensions.IsInstanceOfType(query[0], implementedClosedGenericQueries);
            AssertExtensions.IsInstanceOfType(query[1], implementedClosedGenericQueries);
        }

        [TestMethod]
        public void RegisterDecorator()
        {
            // arrange
            this.container.RegisterType<IQueryHandler<TestQuery, string>, TestQueryHandler>(Lifetime.PerResolve);
            this.container.RegisterType<IQueryHandler<TestQuery, string>, TestQueryHandlerDecorator>(Lifetime.PerResolve);

            this.container.RegisterDecorators(
                typeof(TestQueryHandler),
                new List<Type> { typeof(TestQueryHandlerDecorator) });

            // act
            var tqh = (TestQueryHandler)this.container.Resolve(typeof(IQueryHandler<TestQuery, string>));

            var response = tqh.Handle(new TestQuery());

            // assert
            Assert.AreEqual("Hey there", response);
        }
    }

    /// <summary>
    /// The assert extensions.
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// The is instance of type.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="expectedTypes">
        /// This list should contain an expected type.
        /// </param>
        /// <exception cref="Exception">
        /// Will throw an exception if it can't find an instance in the expected types list
        /// </exception>
        public static void IsInstanceOfType(object value, List<Type> expectedTypes)
        {
            if (expectedTypes.Any(type => type.IsInstanceOfType(value)))
            {
                return;
            }

            throw new Exception("Can't find instance");
        }
    }
}
