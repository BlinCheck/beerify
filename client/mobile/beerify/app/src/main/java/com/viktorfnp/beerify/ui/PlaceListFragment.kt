package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.View
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Place
import com.viktorfnp.beerify.presenter.PlaceListPresenter
import com.viktorfnp.beerify.util.Store
import io.reactivex.Completable
import io.reactivex.android.schedulers.AndroidSchedulers
import kotlinx.android.synthetic.main.item_list_fragment.*
import java.util.concurrent.TimeUnit

class PlaceListFragment : BaseFragment<PlaceListFragment, PlaceListPresenter>() {

    override val layoutResId = R.layout.item_list_fragment

    override val titleResId = R.string.places_title

    private val adapter = PlaceListAdapter(::onItemClicked)

    override fun initPresenter() {
        presenter = PlaceListPresenter()
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        setToolbar()
        initRecyclerView()
    }

    private fun initRecyclerView() {
        itemList.adapter = adapter
        showProgress()
        Completable
            .complete()
            .delay(1800, TimeUnit.MILLISECONDS)
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe {
                hideProgress()
                adapter.updateList(Store.placeList.sortedBy { it.rating }.reversed())
            }
    }

    private fun onItemClicked(data: Place) {
        Store.selectedPlace = data

        activity?.supportFragmentManager?.run {
            beginTransaction()
                .add(R.id.fragmentContainer, PlaceFragment())
                .commit()
        }
    }
}