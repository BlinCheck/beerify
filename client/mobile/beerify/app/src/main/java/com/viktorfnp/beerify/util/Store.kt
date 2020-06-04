package com.viktorfnp.beerify.util

import com.viktorfnp.beerify.entity.Comment
import com.viktorfnp.beerify.entity.Drink
import com.viktorfnp.beerify.entity.Place

class Store {

    companion object {

        val commentsList = mutableListOf<Comment>(
            Comment(
                id = "id0",
                userName = "Виктор",
                text = "My comment",
                rating = 4
            ),
            Comment(
                id = "id1",
                userName = "Виктор",
                text = "Good comment for bar",
                rating = 5
            ),
            Comment(
                id = "id2",
                userName = "Виктор",
                text = "Corona is good",
                rating = 5
            ),
            Comment(
                id = "id3",
                userName = "Виктор",
                text = "Amazing",
                rating = 5
            )
        )

        val drinksList = mutableListOf<Drink>(
            Drink(
                id = "asdasdaa",
                creatorId = "1",
                name = "Redds",
                photo = "https://produkty24.com.ua/db_pic/products/original/original_1459295214.86721897125244.jpg",
                description = "Good light ale with apple aroma",
                rating = 0.0,
                comments = listOf()
            ),
            Drink(
                id = "asdasdasda",
                creatorId = "1",
                name = "Dark beer Hero",
                photo = "https://ak.picdn.net/shutterstock/videos/28193860/thumb/1.jpg",
                description = "Heavy black drink for real men",
                rating = 0.0,
                comments = listOf()
            ),
            Drink(
                id = "asdqwwe",
                creatorId = "1",
                name = "Corona light",
                photo = "https://products2.imgix.drizly.com/ci-corona-light-7335b19a252eb81a.jpeg?auto=format%2Ccompress&fm=jpg&q=20",
                description = "The most popular beer during 2020 quarantine",
                rating = 5.0,
                comments = listOf(Store.commentsList[2])
            ),
            Drink(
                id = "qwertyu",
                creatorId = "1",
                name = "New beer",
                photo = "https://www.solodok.beer/images/products/kits/weizen/400.jpg",
                description = "My new drink",
                rating = 5.0,
                comments = listOf(Store.commentsList[3])
            )
        )

        val placeList = mutableListOf<Place>(
            Place(
                id = "asdf",
                name = "Good pub",
                photo = "https://beerplace.com.ua/wp-content/uploads/2016/02/Khakov-Pub-Main-room.jpg",
                rating = 4.0,
                description = "A good pub in the famous district of Kharkiv with decent drinks and comfortable atmosphere",
                latitude = 50.01647,
                longitude = 36.222123,
                drinks = listOf(Store.drinksList[0], Store.drinksList[1]),
                comments = listOf(Store.commentsList[0])
            ),
            Place(
                id = "asidjiasddj",
                name = "Amazing pub",
                photo = "https://letsbar.com.ua/media/multiuploader/fat-goose-pub-1.2ef848168ddd5eeb0d12351aea1e64a4d27010d6.jpg",
                rating = 5.0,
                description = "One of the best bars in Kharkiv with elite drinks and exceptional service",
                latitude = 49.995099,
                longitude = 36.21756,
                drinks = listOf(Store.drinksList[1], Store.drinksList[2]),
                comments = listOf(Store.commentsList[1])
            ),
            Place(
                id = "asdfww",
                name = "Viktor's pub",
                photo = "https://beerplace.com.ua/wp-content/uploads/2018/02/le-majour-int-1.jpg",
                rating = 0.0,
                description = "Viktor created this pub",
                latitude = 50.000705,
                longitude = 36.244322,
                drinks = listOf(Store.drinksList[2], Store.drinksList[3]),
                comments = listOf()
            )
        )

        var selectedPlace: Place = placeList[2]
        var selectedDrink: Drink = drinksList[0]
    }
}