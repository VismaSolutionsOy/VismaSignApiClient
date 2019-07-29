# Visma Sign Api Client

Visma Solutions Oy

Visma Sign is a online secure document signing service.

Organization API documentation is found at: https://sign.visma.net/api/docs/v1/

Partner API documentation is found at: https://sign.visma.net/api/docs/v1/

## For who

Library is meant to be production ready implementation for anyone using .NET platform and having
integration with Visma Sign. Main point is that integration can be started right away without 
needing to spend time writing code to use Visma Sign's API.

It is enough to set your API credentials and environment endpoint that you are using. After this you
can create your API requests.

## Example how to create new document using library

`var documentInformation = new DocumentDto("Example");`

`var documentLocation = await signClient.SendRequest<LocationDto>(new CreateDocument(documentInformation));`

`var attachment = await new HttpClient().GetByteArrayAsync("https://sign.visma.net/empty.pdf");`

`await signClient.SendRequest<IdentifierDto>(new AddFileToDocument(documentLocation, "empty.pdf", attachment));`

`var invitations = new AddInvitationsToDocument(documentLocation, new List<InvitationDto>()
{
	new InvitationDto("test@visma.com", null, SignatureType.Strong, "John Visma", Language.Finnish),
});`

`var createdInvitations = await signClient.SendRequest<List<InvitationCreatedDto>>(invitations);`


## How to use

Library requires implementing following interfaces:
1. `ICredentials` which defines credentials that are being used in API calls (contains `InMemoryCredentials`
implementation to get you started).
1. `IEndpoint` which defines endpoint that will be used in API calls (contains `InMemoryEndpoint` 
implementation to get you started)
1. For partner credentials: `IScopes` which defines what scopes will be used when obtaining access token
1. For partner credentials: `ICurrentOrganization`. This interface defined what organization 
will be used in API calls (contains `InMemoryCurrentOrganization implementation to get you started).

API calls are made using ISignClient interface which is implemented by `SignClient`. Examples project has
examples of constructing this class.

There are two different implementations of `IApiRequest` interface which will handle differences 
between organization/partner usage:
1. For organization: `OrganizationApiRequest`
1. For partner: `PartnerApiRequest`

## Examples project

Project contains examples how client library can be used. Examples are found in `Visma.Sign.Api.Client.Examples` project.
It will also contain implementations for `ICredentials`, `IEndpoint`, `IScopes` and `ICurrentOrganization` 
for testing purposes.

## Extendability

If library is not currently implementing resource that you would like to use, 
it is possible to define this new resource without modifying source code.

For new resources to be used, create new `class` that inherits from `ResourceBase` and defined resource
information. `CreateDocument` class can be used as an example.

API responses will be serialized to classes. If there is need to remove / add fields to be serialized,
then new dto class can be defined and used in `ISignClient.SendRequest` calls.