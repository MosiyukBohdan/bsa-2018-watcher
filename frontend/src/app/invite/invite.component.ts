import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { ToastrService } from '../core/services/toastr.service';
import { OrganizationInvitesService } from '../core/services/organization-invites.service';
import { OrganizationInvite } from '../shared/models/organization-invite.model';
import { OrganizationInviteState } from '../shared/models/organization-invite-state.enum';
import { User } from '../shared/models/user.model';
import { Organization } from '../shared/models/organization.model';

@Component({
  selector: 'app-invite',
  templateUrl: './invite.component.html',
  styleUrls: ['./invite.component.sass']
})
export class InviteComponent implements OnInit {

  link: string;
  invite: OrganizationInvite;
  createdByUserName: string;
  organizationName: string;
  organization: Organization;

  isAuthenticated: boolean;
  user: User;

  showLoginForm = false;

  constructor(private activatedRoute: ActivatedRoute,
              private authService: AuthService,
              private router: Router,
              private organizationInvitesService: OrganizationInvitesService,
              private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
       this.link = params['invite'];
    });

    this.authService.currentUser.subscribe(
      userData => {
        this.user = { ...userData };
      }
    );



    this.organizationInvitesService.getByLink(this.link).subscribe(
      result => {
        this.invite = result;
        this.organization = this.invite.organization;
        if (this.user.id) {
          if (this.user.id === this.invite.createdByUser.id) {  // You are already a member of the {org} organization!
            this.toastrService.notice(`You are already a member of the ${this.invite.organization.name} organization!`).then((value) => {
              this.router.navigate(['user']);
            });
          }
          if (this.user.organizations.some( // You are already a member of the {org} organization!
            (x => x.id === this.invite.organizationId))) {
              this.toastrService.notice(`You are already a member of the ${this.invite.organization.name} organization!`).then((value) => {
                this.router.navigate(['user']);
              });
          }
        }
        this.createdByUserName = this.invite.createdByUser.displayName;
        this.organizationName = this.invite.organization.name;
      },
      err => { // This invitу is not valid.
        this.toastrService.notice('This invitу is not valid.').then((value) => {
          this.router.navigate(['user']);
        });
      }
    );
  }

  onAccept() {
    if (this.user.id) {
      this.invite.invitedUserId = this.user.id;
      this.invite.state = OrganizationInviteState.Accepted;
      this.updateInvite();
    } else { // show login form
      this.showLoginForm = true;
    }
  }

  onReject() { // only Authenticated User
    this.invite.invitedUserId = this.user.id;
    this.invite.state = OrganizationInviteState.Declined;
    this.updateInvite();
  }

  updateInvite() {
    this.organizationInvitesService.update(this.invite.id, this.invite).subscribe(
      result => {
        if (result) {
          this.toastrService.success('Invite was updated.');
          this.user.organizations.push(this.invite.organization);
          this.user.lastPickedOrganization = this.invite.organization;
          this.user.lastPickedOrganizationId = this.invite.organizationId;
          this.authService.updateCurrentUser(this.user);
        }
      },
      err => {
        this.toastrService.error('Invite was not updated.');
        console.log(err);
      }
    );

    this.router.navigate(['user']);
  }

  successfulSignIn() {
    this.onAccept();
  }

}
