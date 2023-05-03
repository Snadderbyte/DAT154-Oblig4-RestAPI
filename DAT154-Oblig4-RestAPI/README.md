# How to use this WEBAPI

## User

http://localhost:5292/api/User

http://localhost:5292/api/User/{id}

### GET

Gets all users

Return value example:

````
[
  {
    "id": 1,
    "username": "thomasjenkins",
    "password": "pass123",
    "staff": false,
    "name": "Thomas Jenkins",
    "reservations": [],
    "tasks": []
  }, 
  ...
]
````

### GET

Gets user
Return value example:

````{
  "id": 1,
  "username": "thomasjenkins",
  "password": "pass123",
  "staff": false,
  "name": "Thomas Jenkins",
  "reservations": [],
  "tasks": []
}
````

### POST

http://localhost:5292/api/User

Request body example:

````
{
  "username": "TheYEEEEE",
  "password": "p",
  "staff": false,
  "name": "Kanye West",
  "reservations": [],
  "tasks": []
}
````

Return example:

````
{
  "username": "TheYEEEEE",
  "password": "p",
  "staff": false,
  "name": "Kanye West",
  "reservations": [],
  "tasks": []
}
````

### PUT

http://localhost:5292/api/User/ {id}

Request body example:

````
{
  "username": "TheYEEEEEee",
  "password": "p",
  "staff": false,
  "name": "Kanye West",
  "reservations": [],
  "tasks": []
}
````

### DELETE

http://localhost:5292/api/User/ {id}

---

## Rooms

http://localhost:5292/api/Room

http://localhost:5292/api/Room/{id}

### GET

http://localhost:5292/api/Room

````
[
  {
    "id": 1,
    "number": "1",
    "beds": 2,
    "size": "medium",
    "quality": "lav",
    "reservations": [],
    "tasks": []
  },
  ...
]
````

### GET

http://localhost:5292/api/Room/ {id}

````
{
    "id": 1,
    "number": "1",
    "beds": 2,
    "size": "medium",
    "quality": "lav",
    "reservations": [],
    "tasks": []
}
````

### POST

http://localhost:5292/api/Room

Request example:

````
{
  "number": "420",
  "beds": 0,
  "size": "Big",
  "quality": "Poor",
  "reservations": [],
  "tasks": []
}
````

Return example:

````
{
  "number": "420",
  "beds": 0,
  "size": "Big",
  "quality": "Poor",
  "reservations": [],
  "tasks": []
}
````

### PUT

http://localhost:5292/api/Room/ {id}

Request example:

````
{
  "number": "420",
  "beds": 1,
  "size": "Big",
  "quality": "Poor",
  "reservations": [],
  "tasks": []
}
````

### DELETE

http://localhost:5292/api/Room/ {id}

---

## Reservations

http://localhost:5292/api/Reservation

http://localhost:5292/api/Reservation/{id}

### GET

Return:

````
[
  {
    "id": 1,
    "startDate": "2023-10-05T00:00:00",
    "endDate": "2023-12-05T00:00:00",
    "roomId": 1,
    "customerId": 2,
    "customer": null,
    "room": null
  },
  ...
]
````

### GET

Return:

````
{
    "id": 1,
    "startDate": "2023-10-05T00:00:00",
    "endDate": "2023-12-05T00:00:00",
    "roomId": 1,
    "customerId": 2,
    "customer": null,
    "room": null
}
````

### POST

Requset example:

````
{
    "startDate": "2023-10-05T00:00:00",
    "endDate": "2023-12-05T00:00:00",
    "roomId": 1,
    "customerId": 2,
    "customer": null,
    "room": null
}
````

Returns itself

### PUT

Request example:

````
{
    "startDate": "2023-10-05T00:00:00",
    "endDate": "2023-12-05T00:00:00",
    "roomId": 2,
    "customerId": 2,
    "customer": null,
    "room": null
}
````

### DELETE

http://localhost:5292/api/Reservation/ {id}

---

## Tasks

http://localhost:5292/api/Task

http://localhost:5292/api/Task/{id}

### GET

Return:

````
[
  {
    "id": 1,
    "date": "2023-05-03T00:00:00",
    "status": "Urgent",
    "type": "hitler did nothing wrong",
    "note": "clean",
    "roomId": 2,
    "staffId": 2,
    "room": null,
    "staff": null
  },
  ...
]
````

### GET

Return:

````
{
    "id": 1,
    "date": "2023-05-03T00:00:00",
    "status": "Urgent",
    "type": "hitler did nothing wrong",
    "note": "clean",
    "roomId": 2,
    "staffId": 2,
    "room": null,
    "staff": null
}
````

### POST

Request:

````
{
  "date": "2023-05-03T14:38:08.958Z",
  "status": "Pending",
  "type": "Shit on wall",
  "note": "IT WAS DONALD",
  "roomId": 3,
  "staffId": 6,
  "room": null,
  "staff": null
}
````

Returns itself

### PUT

Request:

````
{
  "date": "2023-05-03T14:38:08.958Z",
  "status": "Pending",
  "type": "Shit on wall",
  "note": "IT WAS DONALD",
  "roomId": 3,
  "staffId": 6,
  "room": null,
  "staff": null
}
````

### DELETE

http://localhost:5292/api/Task/ {id}
