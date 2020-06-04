package com.viktorfnp.beerify.ui

import android.content.Context
import android.os.Bundle
import android.util.Log
import android.view.MenuItem
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.fragment.app.FragmentActivity
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.MainPresenter
import kotlinx.android.synthetic.main.main_activity_layout.*

class MainActivity : BaseActivity<MainActivity, MainPresenter>() {

    override val presenter = MainPresenter()

    override val layoutResId = R.layout.main_activity_layout

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        mainContext = applicationContext;

        setSupportActionBar(toolbar)
        supportActionBar?.setDisplayHomeAsUpEnabled(true)
        enableDrawerToggle()
        navigationView?.setNavigationItemSelectedListener(::onNavigationItemSelected)
        fragmentActivity = this

        presenter.onPlacesNearMapViewCreated()
    }

    private fun enableDrawerToggle() {
        val drawerToggle = ActionBarDrawerToggle(
            this,
            articleMenuDrawerLayout,
            toolbar,
            R.string.open_drawer,
            R.string.close_drawer
        )

        drawerToggle.isDrawerIndicatorEnabled = true
        drawerToggle.syncState()
        articleMenuDrawerLayout.addDrawerListener(drawerToggle)
    }

    fun performTransaction() {
        Log.d("MyLog", "Performing transaction")
        fragmentActivity?.supportFragmentManager?.run {
            beginTransaction()
                .replace(R.id.fragmentContainer, NearbyFragment())
                .commitNow()
        }
    }

    private fun onNavigationItemSelected(item: MenuItem): Boolean {
        articleMenuDrawerLayout.closeDrawers()
        return when (item.itemId) {
            R.id.nearby -> {
                fragmentActivity?.supportFragmentManager?.run {
                    beginTransaction()
                        .replace(R.id.fragmentContainer, NearbyFragment())
                        .commit()
                }
                true
            }

            R.id.places -> {
                fragmentActivity?.supportFragmentManager?.run {
                    beginTransaction()
                        .replace(R.id.fragmentContainer, PlaceListFragment())
                        .commit()
                }
                true
            }

            R.id.drinks -> {
                fragmentActivity?.supportFragmentManager?.run {
                    beginTransaction()
                        .replace(R.id.fragmentContainer, DrinkListFragment())
                        .commit()
                }
                true
            }

            R.id.myPlace -> {
                fragmentActivity?.supportFragmentManager?.run {
                    beginTransaction()
                        .replace(R.id.fragmentContainer, MyPlaceFragment())
                        .commit()
                }
                true
            }

            R.id.logout -> {
                true
            }

            else -> false
        }
    }

    companion object {

        var mainContext: Context? = null
        var fragmentActivity: FragmentActivity? = null;
    }
}