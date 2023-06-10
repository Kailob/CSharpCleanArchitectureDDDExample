# Domain Models


- [Physical Device](#physical-device)
- [Meta Data](#meta-data)
- [IoT Device](#iot-device)
- [Software](#software)
- [Device Module](#device-module)
- [Camera](#camera)
- [Deploy](#deploy)



## Physical Device

```csharp
class PhysicalDevice
{
    PhysicalDevice Create();
    void Update();
    void Delete();
    void AddModule(DeviceModule module);
    void UpdateModule(DeviceModule module);
    void RemoveModule(DeviceModule module);
    void AddCamera(Camera camera);
    void UpdateCamera(Camera camera);
    void RemoveCamera(Camera camera);
    void CreateDeviceInIoTHub();
    void InstallSoftware();
    void DeployModules();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Device Name",
    "description": "Device Description",
    "status": 0,
    "tenantId": "00000000-0000-0000-0000-000000000000",
    "metaData": {
        "id": "00000000-0000-0000-0000-000000000000",
        "macAddress": "96:fa:95:1d:67:4a",
        "ip": "192.158.1.38",
        "username": "deviceUserName",
        "password": "devicepassword",
        "LinuxOS": 0,
    },
    "IoTHubDevice": {
        "id": "00000000-0000-0000-0000-000000000000",
        "status": 0,
        "name": "IoTHubDeviceName",
        "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    },
    "software": {
        "id": "00000000-0000-0000-0000-000000000000",
        "status": 0,
        "log": "",
        "createdDateTime": "2023-01-01T00:00:00.0000000Z",
        "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
    },
    "deviceModules": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "moduleId": "00000000-0000-0000-0000-000000000000",
            "variables": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "moduleId": "00000000-0000-0000-0000-000000000000",
            "variables": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
    ],
    "cameras": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Camera Name",
            "description": "Camera Description",
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "name": "Camera Name",
            "description": "Camera Description",
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
    ],
    "deploys": [
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "manifest": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
        },
        {
            "id": "00000000-0000-0000-0000-000000000000",
            "manifest": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
        },
    ],
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
}
```

## Meta Data

```csharp
class MetaData
{
    MetaData Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "macAddress": "96:fa:95:1d:67:4a",
    "ip": "192.158.1.38",
    "username": "deviceUserName",
    "password": "devicepassword",
    "LinuxOS": 0,
}
```

## IoT Device

```csharp
class IoTDevice
{
    IoTDevice Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "status": 0,
    "name": "IoTHubDeviceName",
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
}
```

## Software

```csharp
class Software
{
    Software Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "status": 0,
    "log": "",
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
}
```

## Device Camera

```csharp
class DeviceModule
{
    DeviceModule Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "moduleId": "00000000-0000-0000-0000-000000000000",
    "variables": {},
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
}
```

## Camera

```csharp
class Camera
{
    Camera Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Camera Name",
    "description": "Camera Description",
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
}
```

## Deploy

```csharp
class Deploy
{
    Deploy Create();
    void Update();
    void Delete();
}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "manifest": {},
    "createdDateTime": "2023-01-01T00:00:00.0000000Z",
}
```
