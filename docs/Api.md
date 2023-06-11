# Clean Architecture With Domain Driven Design

- [API](#api)
 - [Auth](#auth)
    - [Register](#register)
        - [Register Request](#register-request)
        - [Register Response](#register-response)
    - [Login](#login)
        - [Login Request](#login-request)
        - [Login Response](#login-response)
 - [Physical Device](#physical-device)
    - [Create](#create)
        - [Create Request](#create-request)
        - [Create Response](#create-response)
    - [Onboard](#onboard)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Fist",
    "lastName": "Last",
    "email": "email@domain.com",
    "password": "password"
}
```

#### Register Response

```js
200 Ok
```

```json
{
    "id": "GUID",
    "firstName": "Fist",
    "lastName": "Last",
    "email": "email@domain.com",
    "token": "TOKEN"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "email@domain.com",
    "password": "TOKEN"
}
```

#### Login Response

```js
200 Ok
```

```json
{
    "id": "GUID",
    "firstName": "Fist",
    "lastName": "Last",
    "email": "email@domain.com",
    "token": "TOKEN"
}
```

## Physical Device

### Create

```js
POST {{host}}/devices/
```

#### Create Request

```json
{
    "name": "Device Name",
    "description": "Device Description",
    // "status": 0,
    "tenantId": "00000000-0000-0000-0000-000000000000",
    "metaData": {
        "macAddress": "96:fa:95:1d:67:4a",
        "ip": "192.158.1.38",
        "username": "deviceUserName",
        "password": "devicepassword",
        "LinuxOS": 0,
    },
    "IoTHubDevice": {
        "status": 0,
        "name": "IoTHubDeviceName",
        "createdDateTime": "2023-01-01T00:00:00.0000000Z",
    },
    "software": {
        "status": 0,
        "log": "",
        "createdDateTime": "2023-01-01T00:00:00.0000000Z",
        "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
    },
    "deviceModules": [
        {
            "moduleId": "00000000-0000-0000-0000-000000000000",
            "variables": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
        {
            "moduleId": "00000000-0000-0000-0000-000000000000",
            "variables": {},
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
    ],
    "cameras": [
        {
            "name": "Camera Name",
            "description": "Camera Description",
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
        {
            "name": "Camera Name",
            "description": "Camera Description",
            "createdDateTime": "2023-01-01T00:00:00.0000000Z",
            "updatedDateTime": "2023-01-01T00:00:00.0000000Z"
        },
    ]
}
```

#### Create Response

```js
201 Created
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Device Name",
    "description": "Device Description",
    // "status": 0,
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
    ]
}
```