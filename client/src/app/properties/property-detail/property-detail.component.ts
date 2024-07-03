import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';
import { take } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { Property } from 'src/app/_models/property';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { PropertiesService } from 'src/app/_services/properties.service';

@Component({
  standalone: true,
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css'],
  imports: [GalleryModule, RouterModule, CommonModule]
})
export class PropertyDetailComponent implements OnInit {
  property: Property;
  member: Member;
  user: User;
  youtubeVideo: SafeResourceUrl;
  images: GalleryItem[] = [];

  constructor(private propertyService: PropertiesService, private route: ActivatedRoute, 
      private accountService: AccountService, private sanitizer: DomSanitizer) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
   }

  ngOnInit(): void {
    this.loadProperty();
  }

  getImages(): GalleryItem[]{
    const imageUrls: any = [];
    for(const photo of this.property.photos){
      this.images.push( new ImageItem({src: photo.url, thumb: photo.url}));
    }

    return imageUrls;
  }

  loadProperty(){
    
    this.propertyService.getProperty(this.route.snapshot.params['id']).subscribe(property => {
      this.property = property;
      this.youtubeVideo = this.sanitizer.bypassSecurityTrustResourceUrl(property.youtubeLink);
      this.getImages();
      this.member = this.property.appUser;
    })
  }

}
