from flask import Flask, request, jsonify
import pickle
import os

# ------------------ AYARLAR ------------------
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
MODEL_DIR = os.path.join(BASE_DIR, "modeller")

MODEL_PATHS = {
    "logistic": "lojistik_regresyon_dengeli.pkl",
    "svm": "lineer_svm_dengeli.pkl",
    "rf": "rastgele_orman_dengeli.pkl"
}

VECTORIZER_PATH = "tfidf_vectorizer.pkl"
CLASS_AI = "AI"

# ------------------ FLASK ------------------
app = Flask(__name__)

# ------------------ MODELLERİ TEK SEFER YÜKLE ------------------
def load_assets():
    with open(os.path.join(MODEL_DIR, VECTORIZER_PATH), "rb") as f:
        vectorizer = pickle.load(f)

    models = {}
    for key, filename in MODEL_PATHS.items():
        with open(os.path.join(MODEL_DIR, filename), "rb") as f:
            models[key] = pickle.load(f)

    return vectorizer, models

VECTORIZER, MODELS = load_assets()

# ------------------ METİN ÖN İŞLEME ------------------
def preprocess(text: str) -> str:
    return str(text).lower().strip()

# ------------------ API ENDPOINT ------------------
@app.route("/predict", methods=["POST"])
def predict():
    try:
        data = request.get_json()
        text = data.get("text", "")

        if not text.strip():
            return jsonify({"error": "Metin boş olamaz"}), 400

        text = preprocess(text)
        X = VECTORIZER.transform([text])

        response = {}

        # ---------- Logistic ----------
        probs = MODELS["logistic"].predict_proba(X)[0]
        ai_index = list(MODELS["logistic"].classes_).index(CLASS_AI)
        response["logisticAI"] = round(probs[ai_index] * 100, 2)
        response["logisticHuman"] = round((1 - probs[ai_index]) * 100, 2)

        # ---------- SVM ----------
        probs = MODELS["svm"].predict_proba(X)[0]
        ai_index = list(MODELS["svm"].classes_).index(CLASS_AI)
        response["svmAI"] = round(probs[ai_index] * 100, 2)
        response["svmHuman"] = round((1 - probs[ai_index]) * 100, 2)

        # ---------- Random Forest ----------
        probs = MODELS["rf"].predict_proba(X)[0]
        ai_index = list(MODELS["rf"].classes_).index(CLASS_AI)
        response["randomForestAI"] = round(probs[ai_index] * 100, 2)
        response["randomForestHuman"] = round((1 - probs[ai_index]) * 100, 2)

        return jsonify(response)

    except Exception as e:
        return jsonify({"error": str(e)}), 500


# ------------------ ÇALIŞTIR ------------------
if __name__ == "__main__":
    print("API BAŞLATILIYOR...")
    app.run(host="0.0.0.0", port=5000, debug=True)
