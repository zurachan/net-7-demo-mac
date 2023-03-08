import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './layout/footer/footer.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { StoreComponent } from './page/store/store.component';
import { StaffComponent } from './page/staff/staff.component';
import { ModalComponent } from './shared/modal/modal.component';
import { StoreDetailComponent } from './page/store/store.detail/store.detail.component';
import { LoginComponent } from './layout/login/login.component';
import { UnauthenticatedContentModule } from './unauthenticated-content';
import { SinglecardModule } from './layout/singlecard/singlecard.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavbarComponent,
    SidenavComponent,
    StoreComponent,
    StaffComponent,
    ModalComponent,
    StoreDetailComponent,
    LoginComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule, UnauthenticatedContentModule, SinglecardModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
