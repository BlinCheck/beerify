package com.viktorfnp.beerify.ui

import android.view.LayoutInflater
import android.view.ViewGroup
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Place

class PlaceListAdapter(private val itemClickListener: (Place) -> Unit) :
    BaseViewAdapter<Place>() {

    override fun getViewHolderByViewType(
        inflater: LayoutInflater,
        viewType: Int,
        parent: ViewGroup
    ) =
        PlaceViewHolder(
            inflater.inflate(R.layout.list_item, parent, false),
            itemClickListener
        )
}