package com.viktorfnp.beerify.repository

import com.viktorfnp.beerify.entity.Place
import com.viktorfnp.beerify.util.Store
import io.reactivex.Flowable
import java.util.concurrent.TimeUnit

class StoreRepository {

    fun getPlaces(): Flowable<List<Place>> {
        return Flowable.fromCallable { Store.placeList as List<Place> }.delay(2, TimeUnit.SECONDS)
    }
}