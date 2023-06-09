# Domain Models


- [Module](#module)


## Module

```csharp
class Module
{
    Module Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Module Name",
    "description": "Module Description",
    "dockerImage": "docker-image",
    "physicalDeviceIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
    ],
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
}
```