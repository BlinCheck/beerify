package com.viktorfnp.beerify.ui

import android.R as androidR
import android.content.Context
import android.os.Bundle
import android.view.View
import android.widget.ArrayAdapter
import android.widget.Toast
import com.bumptech.glide.Glide
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.PlacePresenter
import com.viktorfnp.beerify.util.Store
import io.reactivex.Completable
import io.reactivex.android.schedulers.AndroidSchedulers
import kotlinx.android.synthetic.main.place_details_fragment.*
import java.util.concurrent.TimeUnit


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

        drinksBtn.setOnClickListener {
            Store.selectedDrinks = Store.selectedPlace.drinks
            MainActivity.fragmentActivity?.supportFragmentManager?.run {
                beginTransaction()
                    .replace(R.id.fragmentContainer, DrinkListFragment())
                    .commit()
            }
        }

        sendButton.setOnClickListener {
            showProgress()
            Completable
                .complete()
                .delay(2500, TimeUnit.MILLISECONDS)
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe {
                    hideProgress()
                    Toast.makeText(context, "Thank you. Your comment was sent.", Toast.LENGTH_LONG).show()
                }
        }
    }
}