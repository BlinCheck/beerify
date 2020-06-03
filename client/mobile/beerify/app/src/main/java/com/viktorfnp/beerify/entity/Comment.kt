package com.viktorfnp.beerify.entity

data class Comment(
    var id: String,
    var userName: String,
    var text: String,
    var rating: Int
)