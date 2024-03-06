# API Testing Document

## 1. Genre API

### 1.1 Post Genre

- **Status:** Pass
- **Test Steps:**
  1. Send a POST request to create a new genre.
  2. Verify that the response status code is 200 (OK).
  3. Check if the genre is successfully created in the database.

### 1.2 Get Genres

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve all genres.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains the expected genres.

### 1.3 Delete Genre

- **Status:** Pass
- **Test Steps:**
  1. Send a DELETE request to delete a genre by its ID.
  2. Verify that the response status code is 204 (No Content).
  3. Ensure that the genre is successfully deleted from the database.

### 1.4 Get Genre by genreId

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve a genre by its ID.
  2. Verify that the response status code is 200 (OK).
  3. Check if the returned genre matches the expected genre.

### 1.5 Put Genre by genreId

- **Status:** Pass
- **Test Steps:**
  1. Send a PUT request to update a genre by its ID.
  2. Verify that the response status code is 200 (OK).
  3. Ensure that the genre is successfully updated in the database.

### 1.6 Get Songs by genreId

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve songs by genre ID.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains the expected songs for the given genre.

### 1.7 AddGenreToSong

- **Status:** Pass
- **Test Steps:**
  1. Send a POST request to add a genre to a song.
  2. Verify that the response status code is 200 (OK).
  3. Ensure that the genre is successfully added to the song in the database.

### 1.8 Get Genres by Popularity

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve genres by popularity.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains genres sorted by popularity.

## 2. Song API

### 2.1 Get Songs

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve all songs.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains the expected songs.

### 2.2 Delete Song by songId

- **Status:** Pass
- **Test Steps:**
  1. Send a DELETE request to delete a song by its ID.
  2. Verify that the response status code is 204 (No Content).
  3. Ensure that the song is successfully deleted from the database.

### 2.3 Put Song by songId

- **Status:** Pass
- **Test Steps:**
  1. Send a PUT request to update a song by its ID.
  2. Verify that the response status code is 200 (OK).
  3. Ensure that the genre is successfully updated in the database.

## 3. Artist API

### 3.1 Get Artists

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve all artists.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains the expected artists.

### 3.2 Post Artist

- **Status:** Pass
- **Test Steps:**
  1. Send a POST request to create a new artist.
  2. Verify that the response status code is 200 (OK).
  3. Check if the artist is successfully created in the database.

### 3.3 Delete Artist

- **Status:** Pass
- **Test Steps:**
  1. Send a DELETE request to delete an artist by its ID.
  2. Verify that the response status code is 204 (No Content).
  3. Ensure that the artist is successfully deleted from the database.

### 3.4 Get Artists by artistId

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve an artist by its ID.
  2. Verify that the response status code is 200 (OK).
  3. Check if the returned artist matches the expected artist.

### 3.5 Get Artists by artistId by related

- **Status:** Pass
- **Test Steps:**
  1. Send a GET request to retrieve related artists by an artist ID.
  2. Verify that the response status code is 200 (OK).
  3. Check if the response contains related artists.