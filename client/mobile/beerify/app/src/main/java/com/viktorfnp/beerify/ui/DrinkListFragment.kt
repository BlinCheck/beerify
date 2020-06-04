package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.View
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.entity.Drink
import com.viktorfnp.beerify.presenter.DrinkListPresenter
import com.viktorfnp.beerify.util.Store
import kotlinx.android.synthetic.main.item_list_fragment.*

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
        adapter.updateList(Store.drinksList.sortedBy { it.rating }.reversed())
    }

    private fun onItemClicked(data: Drink) {
        Store.selectedDrink = data

        activity?.supportFragmentManager?.run {
            beginTransaction()
                .add(R.id.fragmentContainer, DrinkFragment())
                .commit()
        }
    }

}