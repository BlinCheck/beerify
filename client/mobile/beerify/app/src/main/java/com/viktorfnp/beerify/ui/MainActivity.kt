package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.view.MenuItem
import androidx.appcompat.app.ActionBarDrawerToggle
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.MainPresenter
import kotlinx.android.synthetic.main.main_activity_layout.*

class MainActivity : BaseActivity<MainActivity, MainPresenter>() {

    override val presenter = MainPresenter()

    override val layoutResId = R.layout.main_activity_layout

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setSupportActionBar(toolbar)
        supportActionBar?.setDisplayHomeAsUpEnabled(true)
        enableDrawerToggle()
        navigationView?.setNavigationItemSelectedListener(::onNavigationItemSelected)
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

    private fun onNavigationItemSelected(item: MenuItem): Boolean =
        when (item.itemId) {
            R.id.nearby -> {
                true
            }

            R.id.places -> {
                true
            }

            R.id.drinks -> {
                true
            }

            R.id.myPlace -> {
                true
            }

            R.id.profile -> {
                true
            }

            R.id.logout -> {
                true
            }

            else -> false
        }

}