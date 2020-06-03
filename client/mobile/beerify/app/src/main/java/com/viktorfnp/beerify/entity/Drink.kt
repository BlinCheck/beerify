package com.viktorfnp.beerify.entity

data class Drink(
    var id: String,
    var creatorId: String,
    var name: String,
    var photo: String,
    var description: String,
    var rating: Double,
    var comments: List<Comment>
)