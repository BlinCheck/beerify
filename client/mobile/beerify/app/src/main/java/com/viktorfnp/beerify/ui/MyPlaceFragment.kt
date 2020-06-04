package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.View
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.MyPlacePresenter
import com.viktorfnp.beerify.util.Store
import io.reactivex.Completable
import io.reactivex.android.schedulers.AndroidSchedulers
import kotlinx.android.synthetic.main.my_place_layout.*
import kotlinx.android.synthetic.main.my_place_layout.description
import kotlinx.android.synthetic.main.my_place_layout.drinksBtn
import kotlinx.android.synthetic.main.my_place_layout.imageView2
import kotlinx.android.synthetic.main.my_place_layout.rating
import kotlinx.android.synthetic.main.my_place_layout.recyclerView
import kotlinx.android.synthetic.main.my_place_layout.title
import kotlinx.android.synthetic.main.place_details_fragment.*
import java.util.concurrent.TimeUnit

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

        drinksBtn.setOnClickListener {
            Store.selectedDrinks = Store.selectedPlace.drinks
            MainActivity.fragmentActivity?.supportFragmentManager?.run {
                beginTransaction()
                    .replace(R.id.fragmentContainer, DrinkListFragment())
                    .commit()
            }
        }

        drinksBtn2.setOnClickListener {
            MainActivity.fragmentActivity?.supportFragmentManager?.run {
                beginTransaction()
                    .replace(R.id.fragmentContainer, DrinkListFragment())
                    .commit()
            }
        }
    }

}