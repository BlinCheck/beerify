package com.viktorfnp.beerify.util

import android.graphics.Color
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.model.BitmapDescriptor
import com.google.android.gms.maps.model.CircleOptions
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.MarkerOptions
import kotlin.math.ln

object MapUtil {

    private const val MIN_RADIUS_OF_SEARCH_IN_MT = 1000.0
    private const val ZERO_COORDINATE = 0.0

    fun createCircle(
        googleMap: GoogleMap,
        radiusOfSearchMt: Double = MIN_RADIUS_OF_SEARCH_IN_MT,
        currentPosition: LatLng = LatLng(ZERO_COORDINATE, ZERO_COORDINATE),
        color: Int = Color.TRANSPARENT
    ) = googleMap
        .addCircle(
            CircleOptions()
                .center(currentPosition)
                .radius(radiusOfSearchMt)
                .strokeColor(Color.RED)
                .fillColor(color)
        )!!

    fun createMarkerOptions(
        latitude: Double,
        longitude: Double,
        bitmapDescriptor: BitmapDescriptor
    ) = MarkerOptions()
        .position(LatLng(latitude, longitude))
        .icon(bitmapDescriptor)!!

    fun getZoomByRadius(radiusMt: Double) = (16 - ln(radiusMt / 300) / ln(2.0)).toFloat()
}