package com.viktorfnp.beerify.repository

import com.tbruyelle.rxpermissions2.RxPermissions
import com.viktorfnp.beerify.ui.MainActivity
import com.viktorfnp.beerify.ui.NearbyFragment
import io.reactivex.Completable
import java.util.concurrent.TimeUnit

class PermissionsRepository {

    fun requestPermissions(vararg permissions: String): Completable =
        RxPermissions(MainActivity.fragmentActivity!!)
            .request(*permissions)
            .flatMapCompletable {
                if (it) Completable.complete().delay(2, TimeUnit.SECONDS)
                else Completable.error(Exception())
            }
}