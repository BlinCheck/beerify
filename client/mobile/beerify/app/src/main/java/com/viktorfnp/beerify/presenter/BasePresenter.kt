package com.viktorfnp.beerify.presenter

import androidx.annotation.VisibleForTesting
import com.viktorfnp.beerify.ui.BaseView
import io.reactivex.disposables.CompositeDisposable

abstract class BasePresenter<V : BaseView>() {

    @VisibleForTesting(otherwise = VisibleForTesting.PROTECTED)
    var view: V? = null

    @VisibleForTesting(otherwise = VisibleForTesting.PROTECTED)
    val disposable: CompositeDisposable = CompositeDisposable()

    fun onAttach(view: V) {
        this.view = view
    }

    fun onDetach() {
        disposable.clear()
        view = null
    }
}