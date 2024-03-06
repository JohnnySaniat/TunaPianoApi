# TunaPiano API

## Introduction

Welcome to the TunaPiano API documentation. This API provides endpoints to manage artists, genres, and songs related to the music industry.

## Getting Started

To get started using the TunaPiano API, follow these steps:

1. Clone the repository.
2. Set up the database connection using the provided `TunaPianoApiDbContext`.
3. Run the application.
4. Explore the available endpoints.

## API Endpoints

### Artists

#### Get All Artists
- **Method:** GET
- **Endpoint:** `/artists`
- **Description:** Retrieves all artists stored in the database.

#### Get Artist by ID
- **Method:** GET
- **Endpoint:** `/artists/{artistId}`
- **Description:** Retrieves an artist by their ID along with associated songs.

#### Get Related Artists
- **Method:** GET
- **Endpoint:** `/artists/{artistId}/related`
- **Description:** Retrieves artists related to a given artist based on shared genres.

#### Add Artist
- **Method:** POST
- **Endpoint:** `/artists`
- **Description:** Adds a new artist to the database.

#### Update Artist
- **Method:** PUT
- **Endpoint:** `/artists/{artistId}`
- **Description:** Updates an existing artist's information.

#### Delete Artist
- **Method:** DELETE
- **Endpoint:** `/artists/{artistId}`
- **Description:** Deletes an artist from the database.

### Genres

#### Get All Genres
- **Method:** GET
- **Endpoint:** `/genres`
- **Description:** Retrieves all genres stored in the database.

#### Get Genre by ID
- **Method:** GET
- **Endpoint:** `/genres/{genreId}`
- **Description:** Retrieves a genre by its ID along with associated songs.

#### Get Popular Genres
- **Method:** GET
- **Endpoint:** `/genres/popular`
- **Description:** Retrieves popular genres based on the number of associated songs.

#### Add Genre
- **Method:** POST
- **Endpoint:** `/genres`
- **Description:** Adds a new genre to the database.

#### Update Genre
- **Method:** PUT
- **Endpoint:** `/genres/{genreId}`
- **Description:** Updates an existing genre's information.

#### Delete Genre
- **Method:** DELETE
- **Endpoint:** `/genres/{genreId}`
- **Description:** Deletes a genre from the database.

### Songs

#### Get All Songs
- **Method:** GET
- **Endpoint:** `/songs`
- **Description:** Retrieves all songs stored in the database.

#### Get Song by ID
- **Method:** GET
- **Endpoint:** `/songs/{songId}`
- **Description:** Retrieves a song by its ID along with associated artist and genres.

#### Get Songs by Genre
- **Method:** GET
- **Endpoint:** `/songs/genre/{genreId}`
- **Description:** Retrieves songs filtered by genre.

#### Add Song
- **Method:** POST
- **Endpoint:** `/songs`
- **Description:** Adds a new song to the database.

#### Update Song
- **Method:** PUT
- **Endpoint:** `/songs/{songId}`
- **Description:** Updates an existing song's information.

#### Add Genre to Song
- **Method:** PUT
- **Endpoint:** `/songs/{songId}/genres/{genreId}`
- **Description:** Associates a genre with a specific song.

#### Delete Song
- **Method:** DELETE
- **Endpoint:** `/songs/{songId}`
- **Description:** Deletes a song from the database.

## Author

This API is developed by [Johnnysaniat](https://github.com/johnnysaniat).
