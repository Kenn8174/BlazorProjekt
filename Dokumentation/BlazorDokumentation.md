# Blazor

### Components

Blazor bruger ikke `.cshtml`, men derimod noget der hedder `.razor` ogs� kaldes `Component`.
Disse filer virker meget som `ViewComponents`, som vi kender fra *MVC* og *Razor pages*.
Componens i blazor best�r af b�de `HTML` kode og `C#`.
For at kunne backend kode skal man implentere en `@code` blok, som ser s�dan ud:

```html
    @code {
    
	}
```

Hvis man har flere *components*, kan man vise en *component* inde  i en anden *component*.
Det g�r man ved at skrive det �nskede *component* ind som et HTML element.
F.eks. hvis man har en `Counter` *component*, kan det blive vist s�dan her:

```html
    <Counter />
```

Alle funktionerne f�lger ogs� med, s� hvis du har backend kode inde i `Counter`, kan det blive brugt.

#### Component parametrer

Et *component* kan ogs� have parametrer, som kan bruges hvis man kalder p� et *component* fra en anden *component*.

```html
    @code {
        [Parameter]
        public int Amount { get; set; } = 1;
	}
```

Og hvis man vil bruge parametret.

```html
    <Counter Amount="10"/>
```

#### Route

Et *component* skal altid starte med `@page` efterfulgt af *Routing endpoint*, som indikere hvor brugeren er.

```html
    @page "/Counter"

    URL = localhost:420/Counter
```

### Forms og Validering



### Authentication

En af de mange m�der at bruge Authorize p� en side er at bruge den `@attribute` der hedder `[Authorize]`.
Man kan bruge *parameters* for at g�re authorization mere specifik, med enten `Roles` eller `Policy`.
**Denne m�de kan ikke sendes videre til et `Childcomponent`.**

```html
	@attribute [Authorize(Roles = "admin, superuser")]
```

Hvis man vil Authorize gennem med `Childcomponents` er det bedre at bruge `AuthorizeView component`, som vist l�ngere nede.

```html
    <AuthorizeView>
        <Authorized>
            <h1>Hello, @context.User.Identity.Name!</h1>
            <p>You can only see this content if you're authenticated.</p>
        </Authorized>
        <NotAuthorized>
            <h1>Authentication Failure!</h1>
            <p>You're not signed in.</p>
        </NotAuthorized>
    </AuthorizeView>
```