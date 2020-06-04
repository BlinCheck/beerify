package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.View
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.MyPlacePresenter
import com.viktorfnp.beerify.util.Store
import kotlinx.android.synthetic.main.my_place_layout.*

class MyPlaceFragment : BaseFragment<MyPlaceFragment, MyPlacePresenter>() {

    override val layoutResId = R.layout.my_place_layout

    override val titleResId = R.string.my_place_title

    private val commentAdapter = CommentListAdapter()

    override fun initPresenter() {
        presenter = MyPlacePresenter()
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        setToolbar()
    }

    override fun onResume() {
        super.onResume()

        val place = Store.selectedPlace
        Glide.with(context!!).load(place.photo).into(imageView2)
        title.text = place.name
        rating.text = "Rating: ${place.rating}"
        description.text = place.description

        recyclerView.adapter = commentAdapter
        commentAdapter.updateList(Store.selectedPlace.comments)
    }

}