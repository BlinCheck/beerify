package com.viktorfnp.beerify.ui

import android.R as androidR
import android.content.Context
import android.os.Bundle
import android.view.View
import android.widget.ArrayAdapter
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.PlacePresenter
import com.viktorfnp.beerify.util.Store
import kotlinx.android.synthetic.main.place_details_fragment.*


class PlaceFragment : BaseFragment<PlaceFragment, PlacePresenter>() {

    override val layoutResId = R.layout.place_details_fragment

    override val titleResId = R.string.title_place_fragment

    private val commentAdapter =  CommentListAdapter();

    override fun initPresenter() {
        presenter = PlacePresenter()
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

        val items = arrayOf<String?>("1", "2", "3", "4", "5")
        val adapter: ArrayAdapter<String?> =
            ArrayAdapter(activity?.baseContext as Context, androidR.layout.simple_spinner_dropdown_item, items)
        dropdown.adapter = adapter

        recyclerView.adapter = commentAdapter
        commentAdapter.updateList(Store.selectedPlace.comments)
    }
}