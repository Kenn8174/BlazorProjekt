# Blazor

### Components

Blazor bruger ikke `.cshtml`, men derimod noget der hedder `.razor` også kaldes `Component`.
Disse filer virker meget som `ViewComponents`, som vi kender fra *MVC* og *Razor pages*.
Componens i blazor består af både `HTML` kode og `C#`.
For at kunne backend kode skal man implentere en `@code` blok, som ser sådan ud:

```html
    @code {
    
	}
```

Hvis man har flere *components*, kan man vise en *component* inde  i en anden *component*.
Det gør man ved at skrive det ønskede *component* ind som et HTML element.
F.eks. hvis man har en `Counter` *component*, kan det blive vist sådan her:

```html
    <Counter />
```

Alle funktionerne følger også med, så hvis du har backend kode inde i `Counter`, kan det blive brugt.

#### Component parametrer

Et *component* kan også have parametrer, som kan bruges hvis man kalder på et *component* fra en anden *component*.

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

En af de mange måder at bruge Authorize på en side er at bruge den `@attribute` der hedder `[Authorize]`.
Man kan bruge *parameters* for at gøre authorization mere specifik, med enten `Roles` eller `Policy`.
**Denne måde kan ikke sendes videre til et `Childcomponent`.**

```html
	@attribute [Authorize(Roles = "admin, superuser")]
```

Hvis man vil Authorize gennem med `Childcomponents` er det bedre at bruge `AuthorizeView component`, som vist længere nede.

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