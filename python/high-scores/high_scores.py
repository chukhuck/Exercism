def latest(scores: int):
    """Get the latest score"""
    return scores[-1]


def personal_best(scores: int):
    """Get the best score"""
    return max(scores)


def personal_top_three(scores: list):
    """Get top 3 scores"""
    return sorted(scores, reverse=True)[:3]
