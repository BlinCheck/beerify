package com.viktorfnp.beerify.repository

import android.location.Location
import com.google.android.gms.location.FusedLocationProviderClient
import com.viktorfnp.beerify.ui.MainActivity
import io.reactivex.Single

class LocationRepository() {

    private val fusedLocationProviderClient = FusedLocationProviderClient(MainActivity.mainContext!!)

    fun getLocation() =
        Single.create<Location> { emitter ->
            fusedLocationProviderClient
                .lastLocation
                .addOnSuccessListener {
                    if (it != null) {
                        emitter.onSuccess(it)
                    } else {
                        emitter.onError(Exception())
                    }
                }
                .addOnFailureListener { emitter.onError(it) }
        }
}