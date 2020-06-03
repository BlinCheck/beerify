package com.viktorfnp.beerify.ui

import android.os.Bundle
import android.util.Log
import android.view.View
import androidx.fragment.app.Fragment
import com.viktorfnp.beerify.R
import com.viktorfnp.beerify.presenter.NearbyPresenter
import com.viktorfnp.beerify.ui.MainActivity.Companion.fragmentActivity
import kotlinx.android.synthetic.main.nearby_fragment.*

class NearbyFragment : BaseFragment<NearbyFragment, NearbyPresenter>() {

    override val layoutResId = R.layout.nearby_fragment

    override val titleResId = R.string.title_nearby_fragment

    override fun initPresenter() {
        presenter = NearbyPresenter()
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        nearbyFragment = this
        setToolbar()

        Log.d("MyLog", "Created fragment")
        imageView.setOnClickListener {
            fragmentActivity?.supportFragmentManager?.run {
                beginTransaction()
                    .add(R.id.fragmentContainer, NearbyFragment(), "Nearby tag")
                    .commit()
            }
        }
    }

    companion object {

        var nearbyFragment: Fragment? = null
    }
}