Feature: Calculate weight on different planets

Scenario: Calculate weight on Mercury
  Given a user enters a weight of 100 lbs
  And selects the planet "Mercury"
  When the weight on Mercury is calculated
  Then the calculated weight should be 37.8 lbs

Scenario: Entering an invalid weight outside the valid range
  Given a user enters a weight of 600 lbs
  And selects the planet "Mars"
  When the form is submitted
  Then an error message "Invalid weight - Only Available from 1 to 500 lbs" should be displayed
