package com.viktorfnp.beerify.ui

import android.view.LayoutInflater
import android.view.ViewGroup
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Comment

class CommentListAdapter() :
    BaseViewAdapter<Comment>() {

    override fun getViewHolderByViewType(
        inflater: LayoutInflater,
        viewType: Int,
        parent: ViewGroup
    ) =
        CommentViewHolder(inflater.inflate(R.layout.comment_item, parent, false))
}