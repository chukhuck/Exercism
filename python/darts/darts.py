 
def score(x, y):
    outer_radius = 10
    middle_radius = 5
    inner_radius = 1 
    no_target_score = 0
    outer_radius_score = 1
    middle_radius_score = 5
    inner_radius_score = 10

    distance = pow(x*x+y*y, 0.5) 

    if distance <= inner_radius:
        return inner_radius_score
    elif distance <= middle_radius:
        return middle_radius_score
    elif distance <= outer_radius:
        return outer_radius_score
    else:
        return no_target_score
