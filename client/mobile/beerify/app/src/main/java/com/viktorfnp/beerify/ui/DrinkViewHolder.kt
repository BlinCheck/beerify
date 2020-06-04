package com.viktorfnp.beerify.ui

import android.view.View
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.entity.Drink
import kotlinx.android.synthetic.main.list_item.view.*

class DrinkViewHolder(view: View, itemClickListener: (Drink) -> Unit) :
    BaseViewAdapter.ViewHolder<Drink>(view) {

    init {
        itemView.setOnClickListener { itemClickListener.invoke(savedData!!) }
    }

    override fun setContent(data: Drink) {
        Glide.with(itemView)
            .load(data.photo)
            .into(itemView.itemPhoto)

        itemView.commentTitle.text = data.name
        itemView.commentDescription.text = data.description
        itemView.itemRating.text = data.rating.toString()
    }
}