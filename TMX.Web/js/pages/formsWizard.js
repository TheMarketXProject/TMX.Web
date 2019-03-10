/*
 *  Document   : formsWizard.js
 *  Author     : pixelcave
 *  Description: Custom javascript code used in Forms Wizard page
 */

var FormsWizard = function() {

    return {
        init: function() {
            /*
             *  Jquery Wizard, Check out more examples and documentation at http://www.thecodemine.org
             *  Jquery Validation, Check out more examples and documentation at https://github.com/jzaefferer/jquery-validation
             */

            /* Initialize Progress Wizard */
            $('#progress-wizard').formwizard({focusFirstInput: true, disableUIStyles: true, inDuration: 0, outDuration: 0});

            // Get the progress bar and change its width when a step is shown
            var progressBar = $('#progress-bar-wizard');
            progressBar
                .css('width', '33%')
                .attr('aria-valuenow', '33');

            $("#progress-wizard").bind('step_shown', function(event, data){
		if (data.currentStep === 'progress-first') {
                    progressBar
                        .css('width', '33%')
                        .attr('aria-valuenow', '33')
                        .removeClass('progress-bar-warning progress-bar-success')
                        .addClass('progress-bar-danger');
                }
                else if (data.currentStep === 'progress-second') {
                    progressBar
                        .css('width', '66%')
                        .attr('aria-valuenow', '66')
                        .removeClass('progress-bar-danger progress-bar-success')
                        .addClass('progress-bar-warning');
                }
                else if (data.currentStep === 'progress-third') {
                    progressBar
                        .css('width', '100%')
                        .attr('aria-valuenow', '100')
                        .removeClass('progress-bar-danger progress-bar-warning')
                        .addClass('progress-bar-success');
                }
            });

            /* Initialize Basic Wizard */
            $('#basic-wizard').formwizard({disableUIStyles: true, inDuration: 0, outDuration: 0});

            /* Initialize Advanced Wizard with Validation */
            $('#advanced-wizard').formwizard({
                disableUIStyles: true,
                validationEnabled: true,
                validationOptions: {
                    errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page
                    errorElement: 'span',
                    errorPlacement: function(error, e) {
                        e.parents('.form-group > div').append(error);
                    },
                    highlight: function(e) {
                        $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
                        $(e).closest('.help-block').remove();
                    },
                    success: function(e) {
                        // You can use the following if you would like to highlight with green color the input after successful validation!
                        e.closest('.form-group').removeClass('has-success has-error'); // e.closest('.form-group').removeClass('has-success has-error').addClass('has-success');
                        e.closest('.help-block').remove();
                    },
                    //rules: {
                    //    firstName: {
                    //        required: true,
                    //        minlength: 2
                    //    },
                    //    lastName: {
                    //        required: true,
                    //        minlength: 2
                    //    },
                    //    userName: {
                    //        required: true,
                    //        minlength: 2
                    //    },
                    //    gender: {
                    //        required: true,
                    //    },
                    //    ethnicity: {
                    //        required: true,
                    //    },
                    //    //dateOfBirth: {
                    //    //    required: true,
                    //    //},
                    //    email: {
                    //        required: true,
                    //        email: true
                    //    },
                    //    phone: {
                    //        required: true,
                    //        minlength: 10
                    //    },
                    //    //address: {
                    //    //    required: true,
                    //    //    minlength: 10
                    //    //},
                    //    employmentStatusId: {
                    //        required: true                            
                    //    },
                    //    bio: {
                    //        required: true,
                    //        minlength: 10
                    //    },
                    //    programmingExperience: {
                    //        required: true
                    //    },
                    //    workExperience: {
                    //        required: true
                    //    },
                    //    extraCurricularActivities: {
                    //        required: true
                    //    },
                    //    learningObjective: {
                    //        required: true
                    //    },
                    //    referredBy: {
                    //        required: true
                    //    },
                    //    desiredTrack: {
                    //        required: true
                    //    },
                    //    desiredCampusLocation: {
                    //        required: true
                    //    },
                    //    //desiredTMXStartDate: {
                    //    //    required: true
                    //    //},
                    //    targetEmploymentLocation: {
                    //        required: true,
                    //        minlength: 2
                    //    },
                    //    accreditationId: {
                    //        required: true
                    //    },
                    //},
                    //messages: {
                    //    firstName: {
                    //        required: "First Name is Required",
                    //        minlength: "At least 2 characters required"
                    //    },
                    //    lastName: {
                    //        required: "Last Name is Required",
                    //        minlength: "At least 2 characters required"
                    //    },
                    //    userName: {
                    //        required: "User Name is Required",
                    //        minlegth: "User Name should have atleast 5 Characters"
                    //    },
                    //    gender: {
                    //        required: "Please provide your Gender"
                    //    },
                    //    ethnicity: {
                    //        required: "Please select an option"
                    //    },
                    //    dateOfBirth: {
                    //        required: "Please enter your date of birth"
                    //    },
                    //    email: {
                    //        required: "Email is Required",
                    //        email: "Your email address must be in the format of name@domain.com "
                    //    },
                    //    phone: {
                    //        required: "Valid Phone Number is Required",
                    //        minlength: "required 10 digits"
                    //    },
                    //    address: {
                    //        required: "Please enter an address"
                    //    },
                    //    employmentStatusId: {
                    //        required: "Please select your employment status"
                    //    },
                    //    bio: {
                    //        required: "This field is required",
                    //        minlegth: "At least 15 Characters"
                    //    },
                    //    programmingExperience: {
                    //        required: "This field is required"
                    //    },
                    //    workExperience: {
                    //        required: "This field is required"
                    //    },
                    //    extraCurricularActivities: {
                    //        required: "This field is required"
                    //    },
                    //    learningObjective: {
                    //        required: "This field is required"
                    //    },
                    //    referredBy: {
                    //        required: "This field is required"
                    //    },
                    //    desiredTrack: {
                    //        required: "Please select a track"
                    //    },
                    //    desiredCampusLocation: {
                    //        required: "Please select a campus"
                    //    },
                    //    desiredTMXStartDate: {
                    //        required: "Please select a desired start date"
                    //    },
                    //    targetEmploymentLocation: {
                    //        required: "This field is required"
                    //    },
                    //    accreditationId: {
                    //        required: "This field is required"
                    //    },
                    //}
                },
                inDuration: 0,
                outDuration: 0
            });

            /* Initialize Clickable Wizard */
            var clickableWizard = $('#clickable-wizard');

            clickableWizard.formwizard({disableUIStyles: true, inDuration: 0, outDuration: 0});

            $('.clickable-steps a').on('click', function(){
                var gotostep = $(this).data('gotostep');

                clickableWizard.formwizard('show', gotostep);
                }
            );
        }
    };
}();