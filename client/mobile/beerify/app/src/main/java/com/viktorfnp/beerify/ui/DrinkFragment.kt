package com.viktorfnp.beerify.ui

import android.content.Context
import android.os.Bundle
import android.view.View
import android.widget.ArrayAdapter
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.DrinkPresenter
import com.viktorfnp.beerify.util.Store
import kotlinx.android.synthetic.main.drink_fragment.*

class DrinkFragment : BaseFragment<DrinkFragment, DrinkPresenter>() {

    override val layoutResId = R.layout.drink_fragment

    override val titleResId = R.string.drink_title

    private val commentsAdapter = CommentListAdapter()

    override fun initPresenter() {
        presenter = DrinkPresenter()
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        setToolbar()
    }

    override fun onResume() {
        super.onResume()

        val drink = Store.selectedDrink
        Glide.with(context!!).load(drink.photo).into(imageView2)
        title.text = drink.name
        rating.text = "Rating: ${drink.rating}"
        description.text = drink.description

        val items = arrayOf<String?>("1", "2", "3", "4", "5")
        val adapter: ArrayAdapter<String?> =
            ArrayAdapter(activity?.baseContext as Context, android.R.layout.simple_spinner_dropdown_item, items)
        dropdown.adapter = adapter

        recyclerView.adapter = commentsAdapter
        commentsAdapter.updateList(Store.selectedDrink.comments)
    }
}