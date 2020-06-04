package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.View
import android.widget.Toast
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Drink
import com.viktorfnp.beerify.presenter.DrinkListPresenter
import com.viktorfnp.beerify.util.Store
import io.reactivex.Completable
import io.reactivex.android.schedulers.AndroidSchedulers
import kotlinx.android.synthetic.main.item_list_fragment.*
import java.util.concurrent.TimeUnit

class DrinkListFragment : BaseFragment<DrinkListFragment, DrinkListPresenter>() {

    override val layoutResId = R.layout.item_list_fragment

    override val titleResId = R.string.drinks_title

    private val adapter = DrinkListAdapter(::onItemClicked)

    override fun initPresenter() {
        presenter = DrinkListPresenter()
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
                adapter.updateList(Store.selectedDrinks.sortedBy { it.rating }.reversed())
            }
    }

    private fun onItemClicked(data: Drink) {
        Store.selectedDrink = data

        activity?.supportFragmentManager?.run {
            beginTransaction()
                .add(R.id.fragmentContainer, DrinkFragment())
                .commit()
        }
    }

    override fun onStop() {
        super.onStop()
        Store.selectedDrinks = Store.drinksList
    }

}