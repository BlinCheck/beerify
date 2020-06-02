package com.viktorfnp.beerify.ui

import androidx.annotation.StringRes

interface BaseView {

    fun showError(@StringRes errorResource: Int)

    fun showProgress()

    fun hideProgress()
}