package com.viktorfnp.beerify.presenter

import com.viktorfnp.beerify.repository.PermissionsRepository
import com.viktorfnp.beerify.ui.MainActivity
import io.reactivex.android.schedulers.AndroidSchedulers

class MainPresenter : BasePresenter<MainActivity>() {

    private val permissionsRepository = PermissionsRepository()

    fun onPlacesNearMapViewCreated() {
        view?.showProgress()
        permissionsRepository
            .requestPermissions(android.Manifest.permission.ACCESS_FINE_LOCATION)
            .subscribeOn(AndroidSchedulers.mainThread())
            .observeOn(AndroidSchedulers.mainThread())
            .subscribe {
                view?.performTransaction()
                view?.hideProgress()
            }
    }
}