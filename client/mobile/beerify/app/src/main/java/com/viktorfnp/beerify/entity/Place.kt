package com.viktorfnp.beerify.entity

data class Place(
    var id: String,
    var name: String,
    var photo: String,
    var rating: Double,
    var description: String,
    var latitude: Double,
    var longitude: Double,
    var drinks: List<Drink>,
    var comments: List<Comment>
)