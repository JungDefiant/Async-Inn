# ERD Lab
**Author:** Bade Habib

## Lab 11
**Collaborators:** Nicco Ryan, Bryant Davis
<br />**Date:** July 20, 2020

## Lab 12
**Date:** July 21, 2020

## Lab 13
**Date:** July 22, 2020

## Lab 14
**Date:** July 23, 2020

### Architecture Pattern
This program is designed to manipulate data between a database and a client via a web connection.

<br /><br />DbContext --> These are the data sets and the seed for a database
<br />Entities --> These are data objects on the .NET/C# side that represent data from a database
<br />Repositories --> These are handlers that determine how data is loaded from the database and returned to objects on the .NET side where the repository is being used
<br />Controllers --> These are handlers that determine how data is dealt with via HTTP requests, including GET, POST, PUT, and Delete

### Route Examples
Different routes return specific data objects.

- **Post "Hotel/{hotelID}/{layoutID}** will add a new hotel room for the specific hotel ID with the specific layout ID.
- **Post "RoomLayouts/{layoutID}/{amenityID}** will add a new Amenity to a specific room layout.

- **Get "Hotel/{id}/HotelRooms"** will get all hotel rooms that are associated with that specific hotel ID, as well as information about those hotel rooms.
```
[
    {
        "hotelID": 1,
        "layoutID": 1,
        "hotel": null,
        "layout": {
            "id": 1,
            "name": "Deluxe",
            "layout": 3,
            "roomAmenities": [
                {
                    "layoutID": 1,
                    "amenityID": 1,
                    "amenity": {
                        "id": 1,
                        "name": "Guy holding a coffee pot in the corner of the room",
                        "roomAmenities": []
                    }
                },
                {
                    "layoutID": 1,
                    "amenityID": 2,
                    "amenity": {
                        "id": 2,
                        "name": "Mentos Dispenser",
                        "roomAmenities": []
                    }
                }
            ]
        },
        "price": 0.00,
        "roomNumber": 0
    },
    {
        "hotelID": 1,
        "layoutID": 2,
        "hotel": null,
        "layout": {
            "id": 2,
            "name": "Business",
            "layout": 1,
            "roomAmenities": []
        },
        "price": 120.00,
        "roomNumber": 101
    }
]
```

- **Get "RoomLayouts/{id}"** will return the specific room layout and all amenities associated with it.
```
{
    "id": 1,
    "name": "Deluxe",
    "layout": 3,
    "roomAmenities": [
        {
            "layoutID": 1,
            "amenityID": 1,
            "amenity": {
                "id": 1,
                "name": "Guy holding a coffee pot in the corner of the room",
                "roomAmenities": []
            }
        },
        {
            "layoutID": 1,
            "amenityID": 2,
            "amenity": {
                "id": 2,
                "name": "Mentos Dispenser",
                "roomAmenities": []
            }
        }
    ]
}
```

### Description
[Click here to view description of Database content!](https://github.com/JungDefiant/Async-Inn/blob/master/Lab11%20ERD%20Descriptions.pdf)

### Database
![Database depiction](https://github.com/JungDefiant/Async-Inn/blob/master/Lab11-Databases%20(1).png)
