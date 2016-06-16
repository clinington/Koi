# Koi

###Introduction

```
'IoC' => 'CoI' => 'Koi'
```

**Koi** (鯉?, English /ˈkɔɪ/, Japanese: [koꜜi]) or more specifically nishikigoi (錦鯉?, [niɕi̥kiꜜɡo.i], literally "brocaded carp"), are a group of fish that are ornamental varieties of domesticated common carp (Cyprinus carpio) that are kept for decorative purposes in outdoor koi ponds or water gardens

A more literal translation is: a random name given to my Dependency Injection Framework.

###Important Notes

1. There is no circular dependency checking - yet.
2. You can register multiple types to a single interface - but at the moment you get the first one registered.

###Getting Started

Initialise a new container:

```
var container = new KoiContainer();
```

Add some dependencies to be resolved:

```
// first way
container.RegisterType(typeof(IEmailService), typeof(EmailService), Lifetime.PerResolve);

// second way
container.RegisterType<IEmailService, EmailService>(Lifetime.PerResolve);
```

Resolve a dependency:

```
var emailService = (EmailService)container.Resolve(tyepof(IEmailService));
```

###Factory Resolution

Use a factory to resolve a dependency:

```
container.RegisterInstance<IEmailService>(() => new EmailService(), Lifetime.PerResolve);
```

###Use Decorators

```
this.container.RegisterType<IEmailService, EmailService>(Lifetime.PerResolve);

this.container.RegisterDecorators(
    typeof(EmailService),
    new List<Type> { typeof(EmailServiceSecurityDecorator) });
```

###Handy Extensions

```
// auto register in assembly
this.container.RegisterTypesFromAssembly(typeof(EmailService).Assembly);
```
