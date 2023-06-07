# Clean Architecture With Domain Driven Design

- [API](#api)
 - [Auth](#auth)
    - [Register](#register)
        - [Register Request](#register-request)
        - [Register Response](#register-response)
    - [Login](#login)
        - [Login Request](#login-request)
        - [Login Response](#login-response)

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