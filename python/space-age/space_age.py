class SpaceAge:
    
    EARTH_ORBITAL_PERIOD_IN_SECONDS = 31557600
    MERCURY_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*0.2408467
    VENUS_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*0.61519726
    MARS_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*1.8808158
    JUPITER_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*11.862615
    SATURN_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*29.447498
    URANUS_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*84.016846
    NEPTUNE_ORBITAL_PERIOD_IN_EARTH_SECS = EARTH_ORBITAL_PERIOD_IN_SECONDS*164.79132
    
    def __init__(self, seconds):
        self.age_in_secs = seconds

    def on_earth(self):
        return round(self.age_in_secs / SpaceAge.EARTH_ORBITAL_PERIOD_IN_SECONDS, 2)

    def on_mercury(self):
        return round(self.age_in_secs 
            / SpaceAge.MERCURY_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_venus(self):
        return round(self.age_in_secs/ SpaceAge.VENUS_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_mars(self):
        return round(self.age_in_secs/ SpaceAge.MARS_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_jupiter(self):
        return round(self.age_in_secs/ SpaceAge.JUPITER_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_saturn(self):
        return round(self.age_in_secs / SpaceAge.SATURN_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_uranus(self):
        return round(self.age_in_secs/ SpaceAge.URANUS_ORBITAL_PERIOD_IN_EARTH_SECS, 2)

    def on_neptune(self):
        return round(self.age_in_secs/SpaceAge.NEPTUNE_ORBITAL_PERIOD_IN_EARTH_SECS, 2)
