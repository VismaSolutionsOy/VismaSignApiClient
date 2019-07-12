# Visma Sign Api Client

Visma Solutions Oy

Visma Sign is a online secure document signing service.

Client API documentation is found at: https://sign.visma.net/api/docs/v1/

Partner API documentation is found at: https://sign.visma.net/api/docs/v1/

## Usage

Client library is ready to be used in production and requires implementing following interfaces:
1. `ICredentials` which defines credentials that are being used in API calls
1. `IEndpoint` which defines endpoint that will be used in API calls
1. For partner credentials: `IScopes` which defines what scopes will be used when obtaining access token
1. For partner credentials: `ICurrentOrganization`. This interface defined what organization will be used in API calls.

API calls are made using ISignClient interface which is implemented by `SignClient`. Examples project has
examples of constructing this class.

There are two different implementations of `IApiRequest` interface which will handle differences 
between client/partner usage:
1. For client: `ClientApiRequest`
1. For partner: `PartnerApiRequest`

## Examples

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