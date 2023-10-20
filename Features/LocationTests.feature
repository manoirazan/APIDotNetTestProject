Feature: Location Tests

Scenario Outline: Get location details for a UK postcode
    When I request for a <countryCode> and a <postCode>
    Then I get a response <response> back from the server
    Examples: 
    | countryCode | postCode | response |
    | gb          | PO6      | OK       |
    | gb          | PO55     | NotFound |

Scenario Outline: Get city details for a UK postcode
    When I request for a <countryCode> and a <postCode>
    Then I get a city <cityName> content back from the server
    Examples: 
    | countryCode | postCode | cityName |
    | gb          | PO6      | cosham   |


