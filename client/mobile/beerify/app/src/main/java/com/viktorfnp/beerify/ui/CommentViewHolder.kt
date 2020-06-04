package com.viktorfnp.beerify.ui

import android.view.View
import com.viktorfnp.beerify.entity.Comment
import kotlinx.android.synthetic.main.comment_item.view.*

class CommentViewHolder(view: View) :
    BaseViewAdapter.ViewHolder<Comment>(view) {

    override fun setContent(data: Comment) {
        itemView.commentTitle.text = data.userName
        itemView.commentDescription.text = data.text
        itemView.commentRating.text = data.rating.toString()
    }
}