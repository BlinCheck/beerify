package com.viktorfnp.beerify.ui

import android.view.LayoutInflater
import android.view.ViewGroup
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Drink

class DrinkListAdapter(private val itemClickListener: (Drink) -> Unit) :
    BaseViewAdapter<Drink>() {

    override fun getViewHolderByViewType(
        inflater: LayoutInflater,
        viewType: Int,
        parent: ViewGroup
    ) =
        DrinkViewHolder(
            inflater.inflate(R.layout.list_item, parent, false),
            itemClickListener
        )
}